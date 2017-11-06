using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {
    private Light light;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
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
