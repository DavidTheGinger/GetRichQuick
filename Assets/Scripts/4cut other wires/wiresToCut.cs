using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiresToCut : MonoBehaviour {
    public GameObject[] correctWires;
    private bool broken;
    private bool spark;
    private Renderer rend;
	// Use this for initialization
	void Start () {
        broken = false;
        spark = false;
	}
	public void brokenState()
    {
        broken = true;
    }
    public bool getBroken()
    {
        return broken;
    }
    public void sparkState()
    {
        spark = true;
    }
    public bool getSpark()
    {
        return spark;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("lockbox light 4").GetComponent<lightDecision4>().getDone())
        {
            return;
        }
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
                if (!spark)
                {
                    brokenState();
                }
            }
        }
    }
}
