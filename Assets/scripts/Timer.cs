using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timertext;
    public Text Score;
    public Color NewColor;
    public GameObject Ending;
    public GameObject Blink;
    public int score = 50;
    public float startTime;

    private int i;
    private bool b;

    // Use this for initialization
    void Start()
    {

        Ending.SetActive(false);

        i = 0;

        b = false;

    }

    //timer blink
    void blink()
    {

        if (Blink.activeInHierarchy)
        {
            Blink.SetActive(false);
        }
        else
        {
            Blink.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

        //Set timer
        float t = startTime - Time.time;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timertext.text = minutes + ":" + seconds;

        //Timer turns red when time is less than 30s
        if (t < 31f)
        {
            timertext.color = NewColor;
        }

        //Timer starts blink when time is less than 15s
        if (t < 15f)
        {
                InvokeRepeating("blink", 0f, 10f);
        }

        //Show ending scene and start counter
        if (t <= 0)
        {
            t = 0;
            Ending.SetActive(true);

            if (i <= score)
            {
                Score.text = "$ " + i;
                i = i + 10;
            }
        }
    }
}
    