using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timertext;
    public Text Score;
    public Color NewColor;
    public GameObject Ending;
    public int score = 50;
    private int i;


    public float startTime;

	// Use this for initialization
	void Start () {

        Ending.SetActive(false);

        i = 0;
		
	}
	
	// Update is called once per frame
	void Update () {
        float t = startTime - Time.time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timertext.text = minutes + ":" + seconds;

        if (t < 31f)
        {
            timertext.color = NewColor;
        }

        if (t <= 0)
        {
            t = 0;
            Ending.SetActive(true);

            if (i <= score)
            {
                Score.text = "$ " + i;
                i = i+10;
            }
        }
	}
}
