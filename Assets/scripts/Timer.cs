using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public Text timertext;
    public Text Score;
    public Text mainScore;
    public Color NewColor;
    public GameObject Ending;
    public GameObject Blink;
    private int score;
    public float startTime;

    private int i;
    private bool b;
    private float t;
	private float diff = 0f;

	public Material testMat;
	AudioSource audio;

    // Use this for initialization
    void Start()
    {
		audio = GetComponent<AudioSource>();
        Ending.SetActive(false);
        t = startTime;
        i = 0;
        //startTime = 300f;
        b = false;
        score = 300;

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

	public float getTimeLeft(){
		return t;
	}

    public void RestartE()
    {
        
        Ending.SetActive(false);
        Time.timeScale = 1;
        t = 300f;
        startTime = Time.time + t;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenuE(string mainmenu)
    {
        SceneManager.LoadScene(mainmenu);
        Ending.SetActive(false);
        Time.timeScale = 1;
        t = 300f;
    }

    public void ExitingGameE()
    {
        Application.Quit();
        Ending.SetActive(false);
        Time.timeScale = 1;
        t = 300f;
    }
    public void changeScore(int amount)
    {
        score += amount;
		//if (amount > 0) {
		//	audio.pitch = Random.Range (.8f, 1.2f);
		//	audio.Play ();
		//	diff = amount / 1000;
			//audio.pitch = Random.Range (.8f, 1.2f);
		//}


    }
    // Update is called once per frame
    void Update()
    {

        //Set timer
       // t = startTime - Time.time;
        t -= Time.deltaTime;
		/*
		if (diff > 0) {
			diff -= Time.deltaTime;
			audio.pitch = Random.Range (.8f, 1.2f);
			audio.loop = true;
		} else {
			audio.loop = false;
		}*/
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timertext.text = minutes + ":" + seconds;
        mainScore.text = "$ " + score;

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
            Time.timeScale = 0;

            if (i <= score/2)
            {
                Score.text = "$ " + i;
				if (score / 2 - i > 10000) {
					i = i + 1000;
				} else if (score / 2 - i > 1000) {
					i = i + 100;
				} else if (score / 2 - i > 100) {
					i = i + 10;
				} else {
					i = i + 1;
				}
                
            }
        }
    }
}
    