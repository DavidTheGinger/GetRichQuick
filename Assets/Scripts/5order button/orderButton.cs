using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orderButton: MonoBehaviour {
    private Light light;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("lockbox light5").GetComponent<lightDecision5>().getDone())
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject.name == gameObject.name)
            { 
                light.enabled = true;
            } else
            {
                light.enabled = false;
            }
        }
        else
        {
            light.enabled = false;
        }

    }
}
