using System.Collections;
using UnityEngine;

class DragTransform : MonoBehaviour
{
    public GameObject[] allOutlets;
    public GameObject correctOutlet;
    private bool correct = false;
    private bool occupied = false;
    private bool dragging = false;
    private float distance;
    private Renderer rend;
    private float duration = 0.1f;
    private float elapsedTime = 0;
    private Vector3 scanPos, screenPoint;
    void Start()
    {
        rend = GetComponent<Renderer>();
        scanPos = gameObject.transform.position;
        screenPoint = Camera.main.WorldToScreenPoint(scanPos);
    }
    /*void OnMouseEnter()
    {
        rend.material.color = mouseOverColor;
    }
    void OnMouseExit()
    {
        rend.material.color = originalColor;
    }*/
    public bool getCorrect()
    {
        return correct;
    }
    public bool getOccupied()
    {
        return occupied;
    }
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
    void OnMouseUp()
    {
        dragging = false;
        
    }
    private void snap(GameObject other)
    {
        while(elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(transform.position, other.transform.position, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
        }
        transform.position = other.transform.position;
    }
    private void FixedUpdate()
    {
        if (dragging)
        {
            Plane plane = new Plane(new Vector3(2, 0, 0), new Vector3(2, 4, 0), new Vector3(1, 1, 0));
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            if (plane.Raycast(ray, out distance))
                transform.position = ray.GetPoint(distance);
        }
        else
        {
            for (int i = 0; i < allOutlets.Length; i++)
            {
                if (Vector3.Distance(transform.position, allOutlets[i].transform.position) < 1)
                {
                    snap(allOutlets[i]);
                    occupied = true;
                }
            }
        }
        if (transform.position == correctOutlet.transform.position)
        {
            correct = true;
        } else
        {
            correct = false;
        }
    }
}