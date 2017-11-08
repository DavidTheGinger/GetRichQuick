using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
    public GameObject[] allOutlets;
    public GameObject correctOutlet;
    public GameObject correctWire;
    public GameObject tangledWire;
    private bool correct = false;
    private bool occupied = false;
    private Light light;
    private int currentState = 0;
    private bool selected;
    void Start()
    {
        light = GetComponent<Light>();
        light.color = new Color(255, 216, 0);
        light.range = 0.5f;
        light.intensity = 1;
        light.enabled = false;

        selected = false;
    }
   
    public int getState()
    {
        return currentState;
    }

    public bool getCorrect()
    {
        return correct;
    }
    public bool getOccupied()
    {
        return occupied;
    }
    public bool getSelected()
    {
        return selected;
    }
    
    void Update()
    {
        if (GameObject.Find("lockbox light 2").GetComponent<lightDecision2>().getDone())
        {
            light.enabled = false;
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject.name == gameObject.name)
            {
                if (Input.GetMouseButtonDown(0) && !selected)
                {
                    selected = true;
                } else if (Input.GetMouseButtonDown(0) && selected)
                {
                    selected = false;
                }
                light.enabled = true;
            }
            else
            {
                if (!selected) light.enabled = false;
            }
        }
        else
        {
            if (!selected) light.enabled = false;
        }
        if (selected)
        {
            if (correctOutlet.GetComponent<outlet>().getSelected())
            {
                correct = true;
                currentState = 1;
                selected = false;
                correctOutlet.GetComponent<outlet>().deSelect();
                Destroy(tangledWire);
                if (correctWire.name == "wireOneStraightPrime (1)")
                    correctWire.transform.localPosition = new Vector3(-0.66f, -8.29f, -9.716f);
                else if (correctWire.name == "wireTwoStraightPrime (1)")
                    correctWire.transform.localPosition = new Vector3(1.36f, -8.30f, -9.716f);
                else if (correctWire.name == "wireThreeStraightPrime (1)")
                    correctWire.transform.localPosition = new Vector3(3.00f, -8.19f, -9.716f);
                else if (correctWire.name == "wireFourStraightPrime (1)")
                    correctWire.transform.localPosition = new Vector3(4.69f, -8.31f, -9.716f);
                else if (correctWire.name == "wireFiveStraightPrime (1)")
                    correctWire.transform.localPosition = new Vector3(6.52f, -8.25f, -9.57f);
                light.enabled = false;
                return;
            }
            foreach(GameObject temp in allOutlets)
            {
                if(temp != correctOutlet)
                {
                    if (temp.GetComponent<outlet>().getSelected())
                    {
                        currentState = -1;
                        selected = false;
                        return;
                    }
                }
            }
            
        }

    }
}