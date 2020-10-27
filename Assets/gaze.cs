using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaze : MonoBehaviour
{
    public GameObject overlayMenu;
    public Camera camera;
    private bool isShowing = false;

    public void Start()
    {
        overlayMenu.SetActive(isShowing);
    }


    public void OnGazeEnter()
    {
        // display menu
        Debug.Log("Gaze entered");

        overlayMenu.transform.position = camera.transform.position + camera.transform.forward * 3;
        overlayMenu.transform.rotation = camera.transform.rotation;

        isShowing = !isShowing;
        overlayMenu.SetActive(isShowing);
    }

    public void OnGazeLeave()
    {
        // hide menu
        Debug.Log("Gaze left");
        isShowing = !isShowing;
        overlayMenu.SetActive(isShowing);
    }
}
