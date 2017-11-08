using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

	public GameObject spinner1;
	public GameObject spinner2;
	public GameObject spinner3;


	public AudioClip pullAud;
	public AudioClip winAud;
	public AudioClip loseAud;

	public GameObject cash;


	private int value1 = -1;
	private int value2 = -1;
	private int value3 = -1;
	private int neededValue = -1;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {

		slotWheel spinner1wheel = spinner1.GetComponent<slotWheel> ();
		slotWheel spinner2wheel = spinner2.GetComponent<slotWheel> ();
		slotWheel spinner3wheel = spinner3.GetComponent<slotWheel> ();

		if (spinner1wheel._state == slotWheel.State.Stopped) {
			value1 = spinner1wheel.getValue ();
			if ((neededValue == -1) || (neededValue == value1)) {
				spinner1wheel.giveValue (value1);
				spinner1wheel.giveValue (value1);
				spinner1wheel.giveValue (value1);
				neededValue = value1;
			}

		}
		if (spinner2wheel._state == slotWheel.State.Stopped) {
			value2 = spinner2wheel.getValue ();
			if ((neededValue == -1) || (neededValue == value2)) {
				spinner1wheel.giveValue (value2);
				spinner2wheel.giveValue (value2);
				spinner3wheel.giveValue (value2);
				neededValue = value2;
			}

		}
		if (spinner3wheel._state == slotWheel.State.Stopped) {
			value3 = spinner3wheel.getValue ();
			if ((neededValue == -1) || (neededValue == value3)) {
				spinner1wheel.giveValue (value3);
				spinner2wheel.giveValue (value3);
				spinner3wheel.giveValue (value3);
				neededValue = value3;
			}

		}


		if(spinner1wheel._state == slotWheel.State.Stopped && spinner2wheel._state == slotWheel.State.Stopped && spinner3wheel._state == slotWheel.State.Stopped ){

			GameObject temp = transform.root.gameObject;

			if (temp) {
				Animator animate = temp.GetComponent<Animator> ();
				if (animate) {
					//animate.speed = 1;
					animate.SetBool("Pulled", false);
					print("can be pulled");
				}
			}





			if ((value1 == value2) && (value1 == value3)) {//if we won
				spinner1wheel.winLoss (slotWheel.State.Won);
				spinner2wheel.winLoss (slotWheel.State.Won);
				spinner3wheel.winLoss (slotWheel.State.Won);
				AudioSource audio = GetComponent<AudioSource>();
				audio.clip = winAud;
				if (!audio.isPlaying) {
					audio.Play ();
					GameObject.Find("UIManager").GetComponent<Timer>().changeScore(200000);
				}

				//Instantiate(cash, new Vector3(2f,2f,2f), Quaternion.identity);


			} else { //if we lost
				spinner1wheel.winLoss (slotWheel.State.Loss);
				spinner2wheel.winLoss (slotWheel.State.Loss);
				spinner3wheel.winLoss (slotWheel.State.Loss);
				AudioSource audio = GetComponent<AudioSource>();
				audio.clip = loseAud;
				if (!audio.isPlaying) {
					audio.Play ();
				}
			}
			//print ("all stopped");
		}


	}

	void OnMouseDown(){



		slotWheel spinner1wheel = spinner1.GetComponent<slotWheel> ();
		slotWheel spinner2wheel = spinner2.GetComponent<slotWheel> ();
		slotWheel spinner3wheel = spinner3.GetComponent<slotWheel> ();
			
		if(spinner1wheel._state == slotWheel.State.Inactive && spinner2wheel._state == slotWheel.State.Inactive && spinner3wheel._state == slotWheel.State.Inactive ){

			GameObject temp = transform.root.gameObject;

			if (temp) {
				Animator animate = temp.GetComponent<Animator> ();
				if (animate) {
					//animate.speed = 1;
					animate.SetBool("Pulled", true);
					print("pulled");
				}
			}


			spinner1wheel.pulled ();
			spinner2wheel.pulled ();
			spinner3wheel.pulled ();
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = pullAud;
			audio.Play ();
			GameObject.Find("UIManager").GetComponent<Timer>().changeScore(-5);

			spinner1wheel.giveValue (-1);
			spinner2wheel.giveValue (-1);
			spinner3wheel.giveValue (-1);
			neededValue = -1;

		}

	}
}
