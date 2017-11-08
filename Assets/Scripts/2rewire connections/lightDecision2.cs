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
            if (allWires[i].GetComponent<DragTransform>().getState() == 1)
            {
                checkOccupied++;
            }

            if (allWires[i].GetComponent<DragTransform>().getState() == -1)
            {
                rend.material.color = wrongColor;
                done = true;
            }



        }


        
        if (checkOccupied == allWires.Length)
        {
            int checkCorrect = 0;
            for (int i = 0; i < allWires.Length; i++)
            {
                if (allWires[i].GetComponent<DragTransform>().getCorrect())
                {
                    checkCorrect++;
                }
                else
                {
                    rend.material.color = wrongColor;
                    done = true;
                }
            }
            if (checkCorrect == allWires.Length)
            {
                rend.material.color = correctColor;
                done = true;
            } 
        }
        
    }
}
