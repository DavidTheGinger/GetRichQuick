using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightDecision4 : MonoBehaviour {
    public GameObject[] wiresToCut;
    public GameObject[] correctWires;
    public GameObject[] allWires;
    private Color wrongColor = Color.grey;
    private Color originalColor = Color.red;
    private Color correctColor = Color.green;
    private Renderer rend;
    private bool checkSpark;
    private int check;
    private ArrayList previousWires;
    private bool done;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = originalColor;
        checkSpark = true;
        check = 0;
        previousWires = new ArrayList();
        done = false;
    }
    public bool getDone()
    {
        return done;
    }

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            return;
        }
            
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            for (int i = 0; i < correctWires.Length; i++)
            {
                if (hit.transform.gameObject.name == correctWires[i].name && Input.GetMouseButtonDown(0))
                {
                    if (correctWires[i].name == "wireTwoStraightPrime (2)")
                        GameObject.Find("snipTwo (1)").transform.localPosition = new Vector3(GameObject.Find("snipTwo (1)").transform.localPosition.x, -9.18f, GameObject.Find("snipTwo (1)").transform.localPosition.z);
                    else if (correctWires[i].name == "wireFourStraightPrime (2)")
                        GameObject.Find("snipFour (1)").transform.localPosition = new Vector3(GameObject.Find("snipFour (1)").transform.localPosition.x, -9.18f, GameObject.Find("snipFour (1)").transform.localPosition.z);
                    Destroy(correctWires[i]);
                    rend.material.color = wrongColor;
                    correctWires[i].GetComponent<wiresToCut>().sparkState();
                    checkSpark = false;
                    done = true;
                }
            }
            for (int j = 0; j < wiresToCut.Length; j++)
            {
                if (hit.transform.gameObject.name == wiresToCut[j].name && Input.GetMouseButtonDown(0) && !previousWires.Contains(wiresToCut[j]))
                {
                    if (wiresToCut[j].name == "wireOneStraightPrime (2)")
                        GameObject.Find("snipOne (1)").transform.localPosition = new Vector3(GameObject.Find("snipOne (1)").transform.localPosition.x, -9.18f, GameObject.Find("snipOne (1)").transform.localPosition.z);
                    else if (wiresToCut[j].name == "wireThreeStraightPrime (2)")
                        GameObject.Find("snipThree (1)").transform.localPosition = new Vector3(GameObject.Find("snipThree (1)").transform.localPosition.x, -9.18f, GameObject.Find("snipThree (1)").transform.localPosition.z);
                    else if (wiresToCut[j].name == "wireFiveStraightPrime (2)")
                        GameObject.Find("snipFive (1)").transform.localPosition = new Vector3(GameObject.Find("snipFive (1)").transform.localPosition.x, -9.18f, GameObject.Find("snipFive (1)").transform.localPosition.z);
                    Destroy(wiresToCut[j]);
                    previousWires.Add(wiresToCut[j]);
                    wiresToCut[j].GetComponent<wiresToCut>().brokenState();
                    check++;
                }
            }
        }

        if (check == wiresToCut.Length && checkSpark)
        {
            rend.material.color = correctColor;
            done = true;
        }
    }
}
