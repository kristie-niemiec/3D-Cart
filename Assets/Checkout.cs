using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Checkout : MonoBehaviour
{
    public Camera camera;
    public GameObject overlayMenu;
    private bool isShowing = false;
    [SerializeField]
    GrabSystem script;
    public GameObject inv;

    // Start is called before the first frame update
    void Start()
    {
        overlayMenu.SetActive(isShowing);

    }

    // Update is called once per frame
    void Update()
    {

        overlayMenu.transform.position = camera.transform.position + camera.transform.forward * 3;
        overlayMenu.transform.rotation = camera.transform.rotation;

        // User selects checkout counter
        if (Input.GetButtonDown("Fire1"))
        {
            var ray = camera.ViewportPointToRay(Vector3.one * 0.5f);
            RaycastHit hit;

            //TODO: add stuff to make sure the object hit is the checkout
            if (Physics.Raycast(ray, out hit, 50))
            {
                // Clear menu items
                inv.GetComponent<Text>().text = "";

                // Show items on menu
                //GameObject temp = GameObject.Find("Character");
                //script = temp.GetComponent<GrabSystem>();

                for (int i = 0; i < script.inventory.Count; i++)
                {
                    Debug.Log("item is: " + script.inventory[i].ToString());
                    inv.GetComponent<Text>().text += script.inventory[i].ToString();
                    inv.GetComponent<Text>().text += "\n";
                }

                // Display inventory
                isShowing = !isShowing;
                overlayMenu.SetActive(isShowing);

            }
        }
    }
}
