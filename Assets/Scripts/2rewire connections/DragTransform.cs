using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
    public GameObject[] allOutlets;
    public GameObject correctOutlet;
    private bool correct = false;
    private bool occupied = false;
    private Light light;
    private bool selected;
    void Start()
    {
        light = GetComponent<Light>();
        light.color = new Color(255, 216, 0);
        light.range = 1;
        light.intensity = 1;
        light.enabled = false;

        selected = false;
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
                if (Input.GetMouseButtonDown(0))
                {
                    selected = true;
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
        if (selected && correctOutlet.GetComponent<outlet>().getSelected())
        {
            correct = true;
        }

    }
}