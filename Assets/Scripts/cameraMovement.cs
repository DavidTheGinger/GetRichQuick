using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {
    public GameObject downArrow;
    public GameObject upArrow;
    public GameObject nod;
    public GameObject shake;
	// Use this for initialization
	void Start () {

	}
	void nodMotion()
    {
    
    }

    void shakeMotion()
    {

    }
    // Update is called once per frame
    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 direction = new Vector3(0.0f, 0.1f, 0.0f);
        if (Physics.Raycast(ray, out hit, 100))
        {
            if (hit.transform.gameObject.name == downArrow.name && Input.GetMouseButton(0))
            {
                if (transform.position.y >= -22)
                {
                    transform.position -= direction;
                    downArrow.transform.position -= direction;
                    upArrow.transform.position -= direction;
                }
            }
            else if (hit.transform.gameObject.name == upArrow.name && Input.GetMouseButton(0))
            {
                if (transform.position.y <= 2)
                {
                    transform.position += direction;
                    downArrow.transform.position += direction;
                    upArrow.transform.position += direction;
                }
            }
        }
	}
}
