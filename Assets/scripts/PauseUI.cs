using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{

    public GameObject PauseMenu;

    private bool paused = false;

    // Use this for initialization
    void Start()
    {

        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("exit"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0;

        }

        if (!paused)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void resume()
    {
        paused = false;
        print ("R");
    }

    public void PauseBtn()
    {
        paused = true;
        print("R");
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void MainMenu(string mainmenu)
    {
        SceneManager.LoadScene(mainmenu);
    }

    public void ExitingGame()
    {
        Application.Quit();
    }
}