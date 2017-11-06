using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallLightDecision : MonoBehaviour {
    public GameObject[] previousLights;
    public GameObject[] postLights;
    public GameObject[] allLights;
    public GameObject button;
    private Color wrongColor = Color.grey;
    private Color originalColor = Color.red;
    private Color correctColor = Color.green;
    private Renderer rend;
    private int check;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
        check = 0;
    }
	void setAllWrongColor()
    {
        for (int i = 0; i < allLights.Length; i++)
        {
            allLights[i].GetComponent<Renderer>().material.color = wrongColor;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject.name == button.name && Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < previousLights.Length; i++)
                {
                    if (previousLights[i].GetComponent<Renderer>().material.color != correctColor)
                    {
                        setAllWrongColor();
                    }
                    else
                    {
                        check++;
                    }
                }
                for (int j = 0; j < postLights.Length; j++)
                {
                    if (postLights[j].GetComponent<Renderer>().material.color != originalColor)
                    {
                        setAllWrongColor();
                    }
                    else
                    {
                        check++;
                    }
                }
                if (check == 4)
                {
                    rend.material.color = correctColor;
                }
            }
        }
    }
}
