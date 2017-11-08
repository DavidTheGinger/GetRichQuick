using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timertext;
    public Color NewColor;
    private float startTime;

	// Use this for initialization
	void Start () {

        startTime = 300.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
        float t = startTime - Time.time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timertext.text = minutes + ":" + seconds;

        if (t <= 30f)
        {
            timertext.color = NewColor;
        }

        if (t <= 0) { t = 0; }
	}
}
