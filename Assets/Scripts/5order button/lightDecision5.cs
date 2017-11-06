using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDecision5 : MonoBehaviour {
    public GameObject[] lights;
    public GameObject lastLight;
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
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].GetComponent<Renderer>().material.color == wrongColor)
            {
                rend.material.color = wrongColor;
            }
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject.name == lastLight.name && Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < lights.Length; i++)
                {
                    if (lights[i].GetComponent<Renderer>().material.color == correctColor)
                    {
                        check++;
                    }
                }
            }
        }

        if (check == 5)
        {
            rend.material.color = correctColor;
        }
    }
}
