using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDecision1 : MonoBehaviour {
    public GameObject correctWire;
    public GameObject[] wrongWires;
    private Color wrongColor = Color.grey;
    private Color originalColor = Color.red;
    private Color correctColor = Color.green;
    private Renderer rend;
    private bool done;
	private bool correct = false;
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
	public bool isCorrect(){
		return correct;
	}

    // Update is called once per frame
    void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (done)
        {
            return;
        }
        if (Physics.Raycast(ray, out hit, 100))
        {
            for (int i = 0; i < wrongWires.Length; i++)
            {
                if (hit.transform.gameObject.name == wrongWires[i].name && Input.GetMouseButtonDown(0))
                {

					AudioSource audio = GetComponent<AudioSource>();
					audio.Play ();
             
                    if (wrongWires[i].name == "wireTwoStraightPrime") 
                        GameObject.Find("snipTwo").transform.localPosition = new Vector3(GameObject.Find("snipTwo").transform.localPosition.x, -0.944f, GameObject.Find("snipTwo").transform.localPosition.z);
                    else if (wrongWires[i].name == "wireThreeStraightPrime")
                        GameObject.Find("snipThree").transform.localPosition = new Vector3(GameObject.Find("snipThree").transform.localPosition.x, -0.944f, GameObject.Find("snipThree").transform.localPosition.z);
                    else if (wrongWires[i].name == "wireFourStraightPrime")
                        GameObject.Find("snipFour").transform.localPosition = new Vector3(GameObject.Find("snipFour").transform.localPosition.x, -0.944f, GameObject.Find("snipFour").transform.localPosition.z);
                    else if (wrongWires[i].name == "wireFiveStraightPrime")
                        GameObject.Find("snipFive").transform.localPosition = new Vector3(GameObject.Find("snipFive").transform.localPosition.x, -0.944f, GameObject.Find("snipFive").transform.localPosition.z);
                    Destroy(wrongWires[i]);
                    rend.material.color = wrongColor;
                    done = true;
                }
            }
            if (hit.transform.gameObject.name == correctWire.name && Input.GetMouseButtonDown(0))
            {
				AudioSource audio = GetComponent<AudioSource>();
				audio.Play ();
                GameObject.Find("snipOne").transform.localPosition = new Vector3(GameObject.Find("snipOne").transform.localPosition.x, -0.944f, GameObject.Find("snipOne").transform.localPosition.z);
                GameObject.Find("openLockBox (1)").GetComponent<Animator>().SetTrigger("get");
                Destroy(correctWire);
				correct = true;
                rend.material.color = correctColor;
                GameObject.Find("UIManager").GetComponent<Timer>().changeScore(10000);
                done = true;
            }
        }
    }
    }
