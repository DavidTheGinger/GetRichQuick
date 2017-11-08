using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDecision2 : MonoBehaviour {
    public GameObject[] allWires;
    public GameObject[] allOutlets;
    private Color wrongColor = Color.grey;
    private Color correctColor = Color.green;
    private Color originalColor = Color.red;
    private Renderer rend;
    private bool done;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
        done = false;
    }

    public bool getDone()
    {
        return done;
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            return;
        }
        int checkOccupied = 0;
        for (int i = 0; i < allWires.Length; i++)
        {
            if (allWires[i].GetComponent<DragTransform>().getSelected())
            {
                checkOccupied++;
            }
            if (allOutlets[i].GetComponent<outlet>().getSelected())
            {
                checkOccupied++;
            }
        }
        if (checkOccupied == 2 * allWires.Length)
        {
            int checkCorrect = 0;
            for (int i = 0; i < allWires.Length; i++)
            {
                if (allWires[i].GetComponent<DragTransform>().getCorrect())
                {
                    checkCorrect++;
                }
            }
            if (checkCorrect == allWires.Length)
            {
                rend.material.color = correctColor;
                done = true;
            } else
            {
                rend.material.color = wrongColor;
                done = true;
            }
        }
    }
}
