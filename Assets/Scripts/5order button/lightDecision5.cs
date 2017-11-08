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
    private bool done;
	private bool correct = false;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
        check = 0;
        done = false;
    }

	public bool isCorrect(){
		return correct;
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
		for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i].GetComponent<Renderer>().material.color == wrongColor)
            {
                rend.material.color = wrongColor;
                done = true;
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
			correct = true;
            GameObject.Find("UIManager").GetComponent<Timer>().changeScore(20000);
            GameObject.Find("openLockBox (5)").GetComponent<Animator>().SetTrigger("get");
            done = true;
        }
    }
}
