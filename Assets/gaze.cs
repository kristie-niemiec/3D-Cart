using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Image))]

public class gaze : MonoBehaviour
{
    public GameObject overlayMenu;
    public GameObject Panel;
    public Camera camera;
    private bool isShowing = false;
    public RaycastHit hitInfo;
    private string assetName;
    public Sprite MenuImg;
    public GameObject inv;

    Vector3 temp = new Vector3(0, 0, 0.3f);

    public void Start()
    {
        overlayMenu.SetActive(isShowing);
    }


    public void OnGazeEnter()
    {
        // Clear menu items
        inv.GetComponent<Text>().text = "";

        // display menu
        Debug.Log("Gaze entered");

        overlayMenu.transform.position = /*camera.transform.position + */temp;
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
            case "Chips":
                MenuImg = Resources.Load<Sprite>("Chips_Menu"); 
                break;
            case "Apple":
                MenuImg = Resources.Load<Sprite>("Apple_Menu");
                break;
            case "banana":
                MenuImg = Resources.Load<Sprite>("Banana_Menu");
                break;
            case "Carrot":
                MenuImg = Resources.Load<Sprite>("Carrot_Menu");
                break;
            case "BeerBox":
                MenuImg = Resources.Load<Sprite>("Box_Menu");
                break;
            case "Bottle":
                MenuImg = Resources.Load<Sprite>("Bottle_Menu");
                break;
            case "SoapBottle":
                MenuImg = Resources.Load<Sprite>("Soap_Menu");
                break;
            case "SprayBottle":
                MenuImg = Resources.Load<Sprite>("Spray_Menu");
                break;
        }

        //overlayMenu.GetComponent<Image>().sprite = MenuImg;
        //Debug.Log(MenuImg);
        isShowing = !isShowing;
        overlayMenu.SetActive(isShowing);
        //overlayMenu.GetComponent<Image>().sprite = MenuImg;
        Panel.GetComponent<Image>().sprite = MenuImg;

    }

    public void OnGazeLeave()
    {
        // hide menu
        Debug.Log("Gaze left");
        Panel.GetComponent<Image>().sprite = null;
        isShowing = !isShowing;
        overlayMenu.SetActive(isShowing);
    }
}
