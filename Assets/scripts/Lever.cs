using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

	public GameObject spinner1;
	public GameObject spinner2;
	public GameObject spinner3;
	//slotWheel spinner1wheel;
	//slotWheel spinner2wheel;
	//slotWheel spinner3wheel;



	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown(){

		//if (spinner1 && spinner2 && spinner3) {

			slotWheel spinner1wheel = spinner1.GetComponent<slotWheel> ();
			slotWheel spinner2wheel = spinner2.GetComponent<slotWheel> ();
			slotWheel spinner3wheel = spinner3.GetComponent<slotWheel> ();

			spinner1wheel.pulled ();
			spinner2wheel.pulled ();
			spinner3wheel.pulled ();
		//}
	}
}
