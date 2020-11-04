using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move;
    public float speed = 1.0f;
    public float walkSpeed = 3.0f;
    public float sprintSpeed = 10.0f;
    public float gravity = 15.0f;
    public Transform cameraDirection;

    public GameObject myCart;
    public Camera camera;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        myCart.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Prevent movement if rotating object
        if(!Input.GetButton("Fire2"))  
        {
            // Prevents character from flying if camera is pointed upwards
            if (controller.isGrounded)
            {
                move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                move = cameraDirection.TransformDirection(move);
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = walkSpeed;
            }

            move.y -= gravity * Time.deltaTime;
            controller.Move(move * Time.deltaTime * speed);

        }





        // if player is not moving - spawn cart
        /*if(!transform.hasChanged)
        {
            // create cart
            GameObject cart = Instantiate(myCart) as GameObject;
            //GameObject item = GameObject.Find(cart);
            // add collider

            // move to position
            myCart.transform.position = camera.transform.position;
            myCart.transform.rotation = camera.transform.rotation;
        }
        else
        {
            //transform.hasChanged = false;
            // destroy when player moves
            //if (item)
            //{
            //    Destroy(GameObject.Find(cart));
            //}
        }*/

    }
}
