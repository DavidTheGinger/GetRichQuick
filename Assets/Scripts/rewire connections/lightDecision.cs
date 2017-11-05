using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDecision : MonoBehaviour {
    public GameObject[] wrongWires;
    public GameObject[] correctWires;
    public GameObject[] veryWrong;
    public GameObject outlet;
    private Color wrongColor = Color.red;
    private Color correctColor = Color.green;
    private Color originalColor = Color.yellow;
    private Renderer rend;
    private bool isOccupied;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
        isOccupied = false;
    }
	
	// Update is called once per frame
	void Update () {
        isOccupied = false;
		for (int i = 0; i < wrongWires.Length; i++)
        {
            if (wrongWires[i].transform.position == outlet.transform.position)
            {
                rend.material.color = wrongColor;
                isOccupied = true;
            }
        }
        for (int i = 0; i < correctWires.Length; i++)
        {
            if (correctWires[i].transform.position == outlet.transform.position)
            {
                rend.material.color = correctColor;
                isOccupied = true;
            }
        }
        if (!isOccupied)
        {
            rend.material.color = originalColor;
        }
	}
}
