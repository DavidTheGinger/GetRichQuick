using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDecision3 : MonoBehaviour {
    public GameObject correctButton;
    public GameObject[] wrongButtons;

    private Color wrongColor = Color.grey;
    private Color originalColor = Color.red;
    private Color correctColor = Color.green;
    private Renderer rend;
    private bool done;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
        done = false;
    }

    public bool getDone()
    {
        return done;
    }

    // Update is called once per frame
    void Update () {
        if (done)
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            for (int i = 0; i < wrongButtons.Length; i++)
            {
                if (hit.transform.gameObject.name == wrongButtons[i].name && Input.GetMouseButtonDown(0))
                {
                    wrongButtons[i].transform.parent.gameObject.GetComponent<Animator>().SetTrigger("click");
                    rend.material.color = wrongColor;
                    done = true;
                }
            }
            if (hit.transform.gameObject.name == correctButton.name && Input.GetMouseButtonDown(0))
            {
                correctButton.transform.parent.gameObject.GetComponent<Animator>().SetTrigger("click");
                rend.material.color = correctColor;
                done = true;
            }
        }
    }
}
