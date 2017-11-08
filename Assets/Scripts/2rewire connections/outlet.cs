using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlet : MonoBehaviour {
    private Light light;
    private bool selected;
    // Use this for initialization
    void Start () {
        light = GetComponent<Light>();
        light.color = new Color(255, 216, 0);
        light.range = 1;
        light.intensity = 1;
        light.enabled = false;
        selected = false;
    }
    public bool getSelected()
    {
        return selected;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("lockbox light 2").GetComponent<lightDecision2>().getDone())
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
                if (Input.GetMouseButtonDown(0))
                {
                    selected = true;
                }
                light.enabled = true;
            }
            else
            {
                if (!selected) light.enabled = false;
            }
        }
        else
        {
            if (!selected) light.enabled = false;
        }

    }
}
