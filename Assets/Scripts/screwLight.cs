using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screwLight : MonoBehaviour {
    public string panelName;
    private Light light;
    // Use this for initialization
    void Start()
    {
        light = GetComponent<Light>();
        light.color = new Color(255, 216, 0);
        light.range = 0.8f;
        light.intensity = 0.5f;
        light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject.name == panelName)
            {
                light.enabled = true;
            }
            else
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
