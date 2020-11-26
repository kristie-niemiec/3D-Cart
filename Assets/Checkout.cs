using System;
using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Checkout : MonoBehaviour
{
    public Camera camera;
    public GameObject overlayMenu;

    public GameObject ckMenu;
    public GameObject inv1;

    private bool active = false;
    private int action = 0;
    private bool isShowing = false;
    [SerializeField]
    GrabSystem script;
    public GameObject inv;

    // Start is called before the first frame update
    void Start()
    {
        overlayMenu.SetActive(isShowing);
        ckMenu.SetActive(active);

        //StartCoroutine(Choice());

    }

    // Update is called once per frame
    void Update()
    {
        overlayMenu.transform.position = camera.transform.position + camera.transform.forward * 2.2f + (camera.transform.right * -.8f) + (camera.transform.up * 0.5f);
        overlayMenu.transform.rotation = camera.transform.rotation;

        // User selects checkout counter
        if (Input.GetButtonDown("Fire1"))
        {
            var ray = camera.ViewportPointToRay(Vector3.one * 0.5f);
            RaycastHit hit;

            // short raycast for checkout
            if (Physics.Raycast(ray, out hit, 10))
            {
                //TODO: add way to remove obj at checkout screen?
                // hits register obj
                if (hit.transform.gameObject.name == "cash_register2")
                {

                    checkoutMenu();


                }
            }


            //TODO: add stuff to make sure the object hit is the checkout
            if (Physics.Raycast(ray, out hit, 50))
            {
                //band-aid fix for checkout list showing up when grabbing cart
                var cartable = hit.transform.GetComponent<PickableCart>();

                if(!cartable && active != true)
                {
                    // Clear menu items
                    inv.GetComponent<Text>().text = "";

                    // Show items on menu
                    //GameObject temp = GameObject.Find("Character");
                    //script = temp.GetComponent<GrabSystem>();

                    for (int i = 0; i < script.inventory.Count; i++)
                    {
                        //Debug.Log("item is: " + script.inventory[i].ToString());
                        inv.GetComponent<Text>().text += script.inventory[i].ToString();
                        inv.GetComponent<Text>().text += "\n";
                    }

                    // Display inventory
                    isShowing = !isShowing;
                    overlayMenu.SetActive(isShowing);
                }

                
            }
        }
        // complete checkout if menu is open
        if(Input.GetButtonDown("Fire2"))
        {
            if(active == true)
            {
                //Debug.Log("checkout complete");

                // clear cart
                // clear inventory list
                for (int i = 0; i < script.inventory.Count; i++)
                {
                    //Debug.Log("item is: " + script.inventory[i].ToString());
                    script.inventory[i] = "";
                    Destroy(script.inventory1[i]);
                }

                active = false;
                ckMenu.SetActive(active);
            }
        }
        // back button for checkout
        if(Input.GetButtonDown("Fire3"))
        {
            if (active == true)
            {
                //Debug.Log("back");
                active = false;
                ckMenu.SetActive(active);
            }
        }
    }

    void checkoutMenu()
    {
        // change scene to checkout menu
        //SceneManager.LoadScene("Checkout");

        inv1.GetComponent<Text>().text = "Items in Cart:";
        inv1.GetComponent<Text>().text += "\n";

        // populate with shopping list
        for (int i = 0; i < script.inventory.Count; i++)
        {
            //Debug.Log("item is: " + script.inventory[i].ToString());
            inv1.GetComponent<Text>().text += script.inventory[i].ToString();
            inv1.GetComponent<Text>().text += "\n";
        }


        // add ui prompt to let user know controls
        //inv1.GetComponent<Text>().text += "\n";
        //inv1.GetComponent<Text>().text = "Proceed with Checkout: ";


        active = true;
        // show checkout ui
        ckMenu.SetActive(active);


        /*if (active)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //checkout completed
                // clear cart
                // clear inventory list
                Debug.Log("checkout complete");
                ckMenu.SetActive(false);
                return;
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                // hide checkout menu
                //active = false;
                return;
            }

            return;
        }*/

        /*switch(action)
        {
            case 1:
               check();
               active = false;
               break;
            case 2:
                back();
                active = false;
                break;
        }

        action++;*/

        //StartCoroutine(Choice());


        //Debug.Log("out of loop");
        //active = false;
        //ckMenu.SetActive(active);

    }

    /*IEnumerator Choice()
    {
        Debug.Log("function started");
        while (active)
        {
            Debug.Log("Loop started");
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("check");
                check();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                Debug.Log("back");
                back();
            }

            yield return null;
        }
    }


    void check()
    {
        //checkout completed
        // clear cart
        // clear inventory list
        Debug.Log("checkout complete");

        active = false;
        ckMenu.SetActive(active);
        return;
    }

    void back()
    {
        // hide checkout menu
        active = false;
        ckMenu.SetActive(active);
        return;
    }*/
}
