using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiresToCut : MonoBehaviour {
    public GameObject[] correctWires;
    private bool broken;
    private bool spark;
    private Color brokenColor = Color.black;
    private Color originalColor = Color.grey;
    private Color sparkColor = Color.yellow;
    private Renderer rend;
	// Use this for initialization
	void Start () {
        broken = false;
        spark = false;
        rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
	}
	void brokenState()
    {
        broken = true;
        rend.material.color = brokenColor;
    }
    public bool getBroken()
    {
        return broken;
    }
    void sparkState()
    {
        spark = true;
        rend.material.color = sparkColor;
    }
    public bool getSpark()
    {
        return spark;
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject.name == gameObject.name && Input.GetMouseButtonDown(0))
            {
                for (int i = 0; i < correctWires.Length; i++)
                {
                    if (correctWires[i].name == gameObject.name)
                    {
                        sparkState();
                    }
                }
                if (rend.material.color != sparkColor)
                {
                    brokenState();
                }
            }
        }
    }
}
