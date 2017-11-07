using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour {
    public GameObject downArrow;
    public GameObject upArrow;
    public GameObject nod;
    public GameObject shake;

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


	// Use this for initialization
	void Start () {
		currentMX = Input.mousePosition.x;
		currentMY = Input.mousePosition.y;
		pastMX = Input.mousePosition.x;
		pastMY = Input.mousePosition.y;
		initialRotation = transform.rotation;
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





			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			Vector3 direction = new Vector3 (0.0f, 0.1f, 0.0f);
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.transform.gameObject.name == downArrow.name && Input.GetMouseButton (0)) {
					if (transform.position.y >= -22) {
						transform.position -= direction;
						downArrow.transform.position -= direction;
						upArrow.transform.position -= direction;
					}
				} else if (hit.transform.gameObject.name == upArrow.name && Input.GetMouseButton (0)) {
					if (transform.position.y <= 2) {
						transform.position += direction;
						downArrow.transform.position += direction;
						upArrow.transform.position += direction;
					}
				}
			}
		}
	}
}
