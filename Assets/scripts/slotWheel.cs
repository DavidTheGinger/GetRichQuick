using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotWheel : MonoBehaviour {

	//States
	private enum State
	{
		Inactive,
		Started,
		Stopped,
		Spinning
	}

	State _state = State.Inactive;

	private Quaternion initialRotation;
	public Quaternion toRotation;
	//public float rotationSpeed = .1f;
	public float nextRotation = 0f;
	public float rotationAMNT = -10f;
	public float minSpeed = -.05f;
	public float snapDistance = 1f;


	private float initialSpeed = -10f;
	public float rotationDecay = 1f;
	public float decayVariation = .3f;

	private float currentItem = -1f;
	private float neededItem = -1f;
	private float initialDecay = 1f;

	private bool canPing = true;
	private float pingDist = 15f;


	public AudioClip spinningAud;
	public AudioClip goodAud;
	public AudioClip betterAud;
	public AudioClip missAud;
	public AudioClip comboAud;

	// Use this for initialization
	void Start () {
		//initialRotation = this.gameObject.transform.rotation;
		//toRotation = Quaternion.Euler(new Vector3(this.gameObject.transform.rotation.x,this.gameObject.transform.rotation.y, 10000));
		initialDecay = rotationDecay;


		AudioSource audio = GetComponent<AudioSource>();
		_state = State.Inactive;

		//audio.Play();
		//yield return new WaitForSeconds(audio.clip.length);
		audio.clip = goodAud;
		audio.Play();

		initialSpeed = rotationAMNT;

	}
	
	// Update is called once per frame
	void Update () {
		AudioSource audio = GetComponent<AudioSource>();
		//transform.rotation = Quaternion.Lerp(initialRotation, toRotation, Time.time * rotationSpeed);
		switch (_state) {
		case State.Inactive:



			break;
		
		case State.Started:
			audio.clip = spinningAud;
			//audio.Play ();
			//audio.loop = true;

			rotationDecay = Random.Range(initialDecay - decayVariation, initialDecay + decayVariation);

			currentItem = -1f;

			rotationAMNT = initialSpeed;
			_state = State.Spinning;

			break;
		
		case State.Spinning:
			if (rotationAMNT == 0f) {
				_state = State.Stopped;
			}

			nextRotation = gameObject.transform.rotation.eulerAngles.z + rotationAMNT;
			if (rotationAMNT < minSpeed) {
				
				rotationAMNT += rotationDecay * Time.deltaTime; 
			}
			if (rotationAMNT >= minSpeed && Mathf.Abs (gameObject.transform.rotation.eulerAngles.z % 45) < snapDistance) {//Stop when we need to
				nextRotation = Mathf.Floor (gameObject.transform.rotation.eulerAngles.z / 45f) * 45f;
				currentItem = nextRotation;
				rotationAMNT = 0f;

			}

			if (Mathf.Abs (gameObject.transform.rotation.eulerAngles.z % 45) < pingDist) {
				if (canPing) {
					audio.Play ();
					canPing = false;
					audio.volume = 1f;
				}
			}

			if (Mathf.Abs (gameObject.transform.rotation.eulerAngles.z % 45) > pingDist) {
				audio.volume -= (45 - pingDist) * Time.deltaTime;

				canPing = true;

			}

			transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 90f,nextRotation));

			break;

		case State.Stopped:
			audio.loop = false;
			audio.clip = goodAud;
			audio.Play ();
			_state = State.Inactive;
			break;
		}


	}


	public void pulled(){
		_state = State.Started;
	}

	void giveValue(float temp){
		neededItem = temp;
	}

	float getValue(){
		return currentItem;
	}

}
