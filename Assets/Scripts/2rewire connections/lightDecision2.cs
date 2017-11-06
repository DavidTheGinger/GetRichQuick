using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDecision2 : MonoBehaviour {
    public GameObject[] allWires;
    private Color wrongColor = Color.grey;
    private Color correctColor = Color.green;
    private Color originalColor = Color.red;
    private Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
    }

    // Update is called once per frame
    void Update()
    {
        int checkOccupied = 0;
        for (int i = 0; i < allWires.Length; i++)
        {
            if (allWires[i].GetComponent<DragTransform>().getOccupied())
            {
                checkOccupied++;
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
            }
            if (checkCorrect == allWires.Length)
            {
                rend.material.color = correctColor;
            } else
            {
                rend.material.color = wrongColor;
            }
        }
    }
}
