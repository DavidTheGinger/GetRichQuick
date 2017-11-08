using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{

    public float maxRotation = 70f;

    private Quaternion initialRotation;


    public enum State
    {
        DefaultState,
        FrontOff,
        One,
        Two,
        Three,
        Four,
        Five
    }

    public State _state = State.DefaultState;

    private bool been1 = false;
    private bool been2 = false;
    private bool been3 = false;
    private bool been4 = false;
    private bool been5 = false;


    private float currentMX = 0f;
    private float currentMY = 0f;
    private float pastMX = 0f;
    private float pastMY = 0f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    private float nextX = 0f;
    private float nextY = 0f;
    private float maxY = 0f;
    private float maxX = 0f;
    private bool zoomed = false;
    private bool end = false;
    private Vector3 backPosition;


    //private float maxCamY = 

    // Use this for initialization
    void Start()
    {
        currentMX = Input.mousePosition.x;
        currentMY = Input.mousePosition.y;
        pastMX = Input.mousePosition.x;
        pastMY = Input.mousePosition.y;
        initialRotation = transform.rotation;
        backPosition = new Vector3(transform.position.x, transform.position.y, -9);

    }
    void nodMotion()
    {


        print("nodded");
    }

    void shakeMotion()
    {
        print("shook");
    }

    // Update is called once per frame
    void Update()
    {


        switch (_state)
        {
            case State.DefaultState:
                if (!GameObject.Find("frontPanelRemoved"))
                {
                    _state = State.FrontOff;
                }
                break;
            case State.FrontOff:
                if (!Input.GetKey("down") && !Input.GetKey("up"))
                {
                    transform.position = Vector3.Lerp(transform.position, new Vector3(0f,transform.position.y, -9f), 5 * Time.deltaTime);
                }
                if (!GameObject.Find("panelOne") && !been1)
                {
                    _state = State.One;
                }
                if (!GameObject.Find("panelTwo") && !been2)
                {
                    _state = State.Two;
                }
                if (!GameObject.Find("panelThree") && !been3)
                {
                    _state = State.Three;
                }
                if (!GameObject.Find("panelFour") && !been4)
                {
                    _state = State.Four;
                }
                if (!GameObject.Find("panelFive") && !been5)
                {
                    _state = State.Five;
                }
                break;
            case State.One:
                been1 = true;
                transform.position = Vector3.Lerp(transform.position, new Vector3(-3.6f, 2f, -6f), 5 * Time.deltaTime);
                if (GameObject.Find("lockbox light 1"))
                {
                    if (GameObject.Find("lockbox light 1").GetComponent<lightDecision1>().getDone())
                    {
                        _state = State.FrontOff;
                    }
                }
                break;
            case State.Two:
                been2 = true;
                transform.position = Vector3.Lerp(transform.position, new Vector3(4f, 2f, -6f), 5 * Time.deltaTime);
                if (GameObject.Find("lockbox light 2"))
                {
                    if (GameObject.Find("lockbox light 2").GetComponent<lightDecision2>().getDone())
                    {
                        _state = State.FrontOff;
                    }
                }
                break;
            case State.Three:
                been3 = true;
                transform.position = Vector3.Lerp(transform.position, new Vector3(0.25f, -4.5f, -8f), 5 * Time.deltaTime);
                if (GameObject.Find("lockbox light 3"))
                {
                    if (GameObject.Find("lockbox light 3").GetComponent<lightDecision3>().getDone())
                    {
                        _state = State.FrontOff;
                    }
                }
                break;
            case State.Four:
                been4 = true;
                transform.position = Vector3.Lerp(transform.position, new Vector3(-3.6f, -11f, -6f), 5 * Time.deltaTime);
                if (GameObject.Find("lockbox light 4"))
                {
                    if (GameObject.Find("lockbox light 4").GetComponent<lightDecision4>().getDone())
                    {
                        _state = State.FrontOff;
                    }
                }
                break;
            case State.Five:
                been5 = true;
                transform.position = Vector3.Lerp(transform.position, new Vector3(4f, -11f, -6f), 5 * Time.deltaTime);
                if (GameObject.Find("lockbox light5"))
                {
                    if (GameObject.Find("lockbox light5").GetComponent<lightDecision5>().getDone())
                    {
                        _state = State.FrontOff;
                    }
                }
                break;

        }


        /*
        if (!zoomed)
        {
            if (GameObject.Find("frontPanelRemoved"))
            {
                if (GameObject.Find("frontPanelRemoved").GetComponent<panelMovement>().getDone())
                {
                    print("test");
                    zoomed = true;
                }
            }
            else
            {
                zoomed = true;
            }
        }
        else if (!end)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, -9), 5 * Time.deltaTime);
            if (transform.position.z >= -9)
            {
                end = true;
            }
        }

*/











        if (Input.GetMouseButtonUp(1))
        {

            if (maxX > 5f || maxY > 5f)
            {
                if (maxX > maxY)
                {
                    shakeMotion();
                }
                else
                {
                    nodMotion();
                }
            }

            maxX = 0f;
            maxY = 0f;
        }

        if (Input.GetMouseButton(1))
        {
            currentMX = Input.mousePosition.x;
            currentMY = Input.mousePosition.y;

            //yRotation = (currentMX - pastMX) * (maxRotation / Screen.currentResolution.width);
            //xRotation = -(currentMY - pastMY) * (maxRotation / Screen.currentResolution.height);
            if (Mathf.Abs(currentMX - Screen.currentResolution.width / 2) > maxX)
            {
                maxX = Mathf.Abs(currentMX - Screen.currentResolution.width / 2);
            }
            if (Mathf.Abs(currentMY - Screen.currentResolution.height / 2) > maxY)
            {
                maxY = Mathf.Abs(currentMY - Screen.currentResolution.height / 2);
            }

            yRotation = (currentMX - Screen.currentResolution.width / 2) * (maxRotation / Screen.currentResolution.width);
            xRotation = -(currentMY - Screen.currentResolution.height / 2) * (maxRotation / Screen.currentResolution.height);



            //transform.rotation =  Quaternion.Euler(new Vector3(xRotation, yRotation,transform.rotation.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(xRotation, yRotation, transform.rotation.z)), 7 * Time.deltaTime);


            pastMX = Input.mousePosition.x;
            pastMY = Input.mousePosition.y;
        }
        else
        {


            transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, 7 * Time.deltaTime);

            Vector3 direction = new Vector3(0.0f, 0.1f, 0.0f);
            if (Input.GetKey("down"))
            {
                if (transform.position.y >= -11)
                {
                    transform.position -= direction;
                }
            }
            else if (Input.GetKey("up"))
            {
                if (transform.position.y <= 13)
                {
                    transform.position += direction;
                }
            }
        }
    }
}
