using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {

	public float maxRotation = 70f;

	private Quaternion initialRotation;


	private float currentMX = 0f;
	private float currentMY = 0f;
	private float pastMX = 0f;
	private float pastMY = 0f;
	private float xRotation = 0f;
	private float yRotation = 0f;
	private float nextX = 0f;
	private float nextY = 0f;
	private float maxY = 0f;
	private float maxX = 0f;
    private bool zoomed = false;
    private bool end = false;
    private Vector3 backPosition;

	// Use this for initialization
	void Start () {
		currentMX = Input.mousePosition.x;
		currentMY = Input.mousePosition.y;
		pastMX = Input.mousePosition.x;
		pastMY = Input.mousePosition.y;
		initialRotation = transform.rotation;
        backPosition = new Vector3(transform.position.x, transform.position.y, -9);

    }
	void nodMotion()
    {
    	

		print ("nodded");
    }

    void shakeMotion()
    {
		print ("shook");
    }
		
    // Update is called once per frame
    void Update() {
        if (!zoomed)
        {
            if (GameObject.Find("frontPanelRemoved"))
            {
                if (GameObject.Find("frontPanelRemoved").GetComponent<panelMovement>().getDone())
                {
                    print("test");
                    zoomed = true;
                }
            }
            else
            {
                zoomed = true;
            }
        }
        else if (!end)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, -9), 5 * Time.deltaTime);
            if (transform.position.z >= -9)
            {
                end = true;
            }
        }

        if (Input.GetMouseButtonUp(1)) {

			if (maxX > 5f || maxY > 5f) {
				if (maxX > maxY) {
					shakeMotion ();
				} else {
					nodMotion ();
				}
			}

			maxX = 0f;
			maxY = 0f;
		}

		if (Input.GetMouseButton (1)) {
			currentMX = Input.mousePosition.x;
			currentMY = Input.mousePosition.y;

			//yRotation = (currentMX - pastMX) * (maxRotation / Screen.currentResolution.width);
			//xRotation = -(currentMY - pastMY) * (maxRotation / Screen.currentResolution.height);
			if (Mathf.Abs (currentMX - Screen.currentResolution.width / 2) > maxX) {
				maxX = Mathf.Abs (currentMX - Screen.currentResolution.width / 2);
			}
			if (Mathf.Abs (currentMY - Screen.currentResolution.height / 2) > maxY) {
				maxY = Mathf.Abs (currentMY - Screen.currentResolution.height / 2);
			}

			yRotation = (currentMX - Screen.currentResolution.width/2)* (maxRotation / Screen.currentResolution.width);
			xRotation = -(currentMY - Screen.currentResolution.height/2)* (maxRotation / Screen.currentResolution.height);



			//transform.rotation =  Quaternion.Euler(new Vector3(xRotation, yRotation,transform.rotation.z));
			transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(new Vector3(xRotation, yRotation,transform.rotation.z)),7 * Time.deltaTime );


			pastMX = Input.mousePosition.x;
			pastMY = Input.mousePosition.y;
		} else {


			transform.rotation = Quaternion.Lerp(transform.rotation,initialRotation,7 * Time.deltaTime );

			Vector3 direction = new Vector3 (0.0f, 0.1f, 0.0f);
				if (Input.GetKey("down")) {
					if (transform.position.y >= -11) {
						transform.position -= direction;
					}
				} else if (Input.GetKey("up")) {
					if (transform.position.y <= 13) {
						transform.position += direction;
					}
				}
		}
	}
}
