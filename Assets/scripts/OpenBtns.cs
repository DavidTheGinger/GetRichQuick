using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBtns : MonoBehaviour {

    public GameObject Instruction;
    public GameObject Credits;

    private bool inst = false;
    private bool cred = false;


    // Use this for initialization
    void Start () {

        Instruction.SetActive(false);
        Credits.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("exit"))
        {
            if (inst)
            {
                insBack();
            }
            if (cred)
            {
                creBack();
            }
        }

    }

    public void NewGameBtn(string NewGameLevel)
    {
        SceneManager.LoadScene(NewGameLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ins()
    {
        Instruction.SetActive(true);
        inst = true;
    }

    public void cre()
    {
        Credits.SetActive(true);
        cred = true;
    }

    public void insBack()
    {
        Instruction.SetActive(false);
        inst = false;
    }

    public void creBack()
    {
        Credits.SetActive(false);
        cred = false;
    }
}
