using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDecision1 : MonoBehaviour {
    public GameObject correctWire;
    public GameObject[] wrongWires;

    private Color wrongColor = Color.grey;
    private Color originalColor = Color.red;
    private Color correctColor = Color.green;
    private Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
	}

    // Update is called once per frame
    void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            for (int i = 0; i < wrongWires.Length; i++)
            {
                if (hit.transform.gameObject.name == wrongWires[i].name && Input.GetMouseButtonDown(0))
                {
                    rend.material.color = wrongColor;
                }
            }
            if (hit.transform.gameObject.name == correctWire.name && Input.GetMouseButtonDown(0))
            {
                rend.material.color = correctColor;
            }
        }
    }
}
