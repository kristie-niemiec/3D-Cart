using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class gaze : MonoBehaviour
{
    public GameObject overlayMenu;
    public Camera camera;
    private bool isShowing = false;
    RaycastHit hitInfo;
    private string assetName;
    Sprite MenuImg;
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
        if (Physics.Raycast(
              Camera.main.transform.position,
              Camera.main.transform.forward,
              out hitInfo,
              20.0f,
              Physics.DefaultRaycastLayers))
        {
            assetName = hitInfo.collider.gameObject.name;
        }
       switch (assetName)
        {
            case "Chips32":
                MenuImg = Resources.Load<Sprite>("Chips_Menu"); 
                break;
        }
        //overlayMenu.GetComponent<Image>().sprite = MenuImg;
        //Debug.Log(MenuImg);
        isShowing = !isShowing;
        overlayMenu.SetActive(isShowing);
        overlayMenu.GetComponent<Image>().sprite = MenuImg;
    }

    public void OnGazeLeave()
    {
        // hide menu
        Debug.Log("Gaze left");
        isShowing = !isShowing;
        overlayMenu.SetActive(isShowing);
    }
}
