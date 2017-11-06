using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDecision4 : MonoBehaviour {
    public GameObject[] wiresToCut;
    public GameObject[] correctWires;
    public GameObject[] allWires;
    private Color wrongColor = Color.grey;
    private Color originalColor = Color.red;
    private Color correctColor = Color.green;
    private Renderer rend;
    private bool checkSpark;
    private int check;
    private ArrayList previousWires;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
        checkSpark = true;
        check = 0;
        previousWires = new ArrayList();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            for (int i = 0; i < correctWires.Length; i++)
            {
                if (hit.transform.gameObject.name == correctWires[i].name && Input.GetMouseButtonDown(0))
                {
                    rend.material.color = wrongColor;
                    checkSpark = false;
                }
            }
            for (int j = 0; j < wiresToCut.Length; j++)
            {
                if (hit.transform.gameObject.name == wiresToCut[j].name && Input.GetMouseButtonDown(0) && !previousWires.Contains(wiresToCut[j]))
                {
                    previousWires.Add(wiresToCut[j]);
                    check++;
                }
            }
        }

        if (check == wiresToCut.Length && checkSpark)
        {
            rend.material.color = correctColor;
        }
    }
}
