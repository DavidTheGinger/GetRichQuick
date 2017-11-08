using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelMovement : MonoBehaviour {
    public string pCubeName;
    private Animator anim;
    private bool done;
    private bool zoomin;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        done = false;
        zoomin = false;
	}
    public bool getDone()
    {
        return done;
    }
    public bool getZoomin()
    {
        return zoomin;
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject.name == pCubeName && Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("click");
                zoomin = true;
            }
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            done = true;
            Destroy(gameObject);
        }
    }
}
