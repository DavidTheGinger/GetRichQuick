using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinker : MonoBehaviour {

	public float[] times;
	private Light light;

	private int timesIndex = 0;

	private float timer = 0f;
	private int count = 0;

	public enum State
	{
		End,
		Between,
		Count
	}

	public State _state = State.End;


	// Use this for initialization
	void Start () {
		light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {

		switch (_state) {
		case State.Between:
			light.enabled = false;
			if (timer > 0) {
				timer -= Time.deltaTime;
			} else {
				timer = .5f;

				timesIndex++;
				count = 0;
				if (timesIndex < times.Length) {
					_state = State.Count;
				} else {
					timer = 4f;
					_state = State.End;
				}
			}
			break;
		case State.Count:
			if (timer > 0) {
				timer -= Time.deltaTime;
				light.enabled = true;
				if (timer <= 0) {
					if (count < times [timesIndex] - 1) {
						count++;
						timer = -.5f;
					} else {
						timer = 2f;
						_state = State.Between;
					}
				}

			} else {
				timer += Time.deltaTime;
				if (timer >= 0) {
					timer = .5f;
				}
				light.enabled = false;
			}
			break;

		case State.End:
			if (timer > 0) {
				timer -= Time.deltaTime;
			} else {
				timesIndex = 0;
				count = 0;
				_state = State.Count;
			}

			break;
		}


	}
}
