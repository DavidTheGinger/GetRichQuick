﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {
    private Light light;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
        light.color = new Color(255, 216, 0);
        light.range = 2;
        light.intensity = 1;
        light.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("lockbox light 3").GetComponent<lightDecision3>().getDone())
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
