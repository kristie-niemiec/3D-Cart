//Code adapted from https://www.patrykgalach.com/2020/03/16/pick-up-items-in-unity/

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class GrabSystem : MonoBehaviour
{
    public GameObject currObj;

    //Inventory List
    public List<string> inventory = new List<string>();

    public GameObject text;

    //Character camera
    [SerializeField]
    private Camera characterCamera;

    //Slot for holding item
    [SerializeField]
    private Transform slot;

    //Slot for holding cart
    [SerializeField]
    private Transform cartSlot;

    //Currently held item
    private PickableItem pickedItem;
    private PickableCart pickedCart;

    // Update is called once per frame
    private void Update()
    {
        text.transform.position = characterCamera.transform.position + characterCamera.transform.forward * 1.5f;
        text.transform.rotation = characterCamera.transform.rotation;
        text.SetActive(false);

        //If pickup button pushed
        if (Input.GetButtonDown("Fire1"))
        {
            print("Fire1 Pressed");
            //Check if any item held, drop if so
            if(pickedItem)
            {
                DropItem(pickedItem);
            }
            else if(pickedCart)
            {
                DropCart(pickedCart);
            }
            //Otherwise, try to pick up item in cursor
            else
            {  
                //Create ray to check item in front of camera
                var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
                RaycastHit hit;

                //Check if the item is pickable and then pick up it so
                if(Physics.Raycast(ray, out hit, 10))
                {
                    var pickable = hit.transform.GetComponent<PickableItem>();
                    var cartable = hit.transform.GetComponent<PickableCart>();
                    currObj = hit.collider.gameObject;

                    if (pickable)
                    {
                        PickItem(pickable);
                    }
                    else if (cartable)
                    {
                        PickCart(cartable);
                    }
                }
            }
        }

        //If rotate button pushed
        if (Input.GetButton("Fire2"))
        {
            print("Rotate pressed");

            //Check if any item held, if not do nothing
            if (pickedItem)
            {
                // Show "Rotate Mode" text
                text.SetActive(true);

                var mx = Input.GetAxis("Horizontal");
                var my = Input.GetAxis("Vertical");

                pickedItem.transform.Rotate(my, 0, -mx, Space.Self);
            }
        }

        //Hide rotate text here?
        //text.SetActive(false);

        //Add item to inventory
        if (Input.GetButtonDown("Fire3"))
        {
            print("Add to cart pressed");
            if (pickedItem)
            {
                AddToCart(currObj);
            }

        }
    }

    //Method to pick-up item 
    private void PickItem(PickableItem item)
    {
        //Assign this class's reference to new item
        pickedItem = item;

        //Disable rigidbody & reset velocities
        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;

        //move item to character's slot
        item.transform.SetParent(slot);

        //Reset position and rotation
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
    }

    //Method to pick-up cart
    private void PickCart(PickableCart cart)
    {
        //Assign reference to new item
        pickedCart = cart;

        //Disable rigidbody & reset velocities
        cart.Rb.isKinematic = true;
        cart.Rb.velocity = Vector3.zero;
        cart.Rb.angularVelocity = Vector3.zero;

        //move item to character's slot
        cart.transform.SetParent(cartSlot);

        //Reset position and rotation
        cart.transform.localPosition = Vector3.zero;
        cart.transform.localEulerAngles = Vector3.zero;

        //Rotate cart to face the right way
        cart.transform.Rotate(0, 90, 0);
    }

    //Method to drop item
    private void DropItem(PickableItem item)
    {
        //Remove reference
        pickedItem = null;

        //Remove Parent
        item.transform.SetParent(null);

        //Re-enable rigidbody
        item.Rb.isKinematic = false;

        //Throw item forward slightly
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }

    //Method to drop cart
    private void DropCart(PickableCart cart)
    {
        //Remove reference
        pickedCart = null;

        //Remove Parent
        cart.transform.SetParent(null);

        //Re-enable rigidbody
        cart.Rb.isKinematic = false;

        //Throw item forward slightly
        cart.Rb.AddForce(cart.transform.forward * 2, ForceMode.VelocityChange);
    }

    //Method to add to inventory
    public void AddToCart(GameObject item)
    {
        print("add");

        if(item.name != "Character" && item.name != "Floor" && item.name != "Shelf")
            inventory.Add(item.name);

        //currObj.SetActive(false);

        pickedItem = null;
    }
}
