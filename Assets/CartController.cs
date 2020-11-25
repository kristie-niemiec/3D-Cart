using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartController : MonoBehaviour
{

    public Camera camera;


    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(camera.transform.eulerAngles.x, camera.transform.eulerAngles.y, camera.transform.eulerAngles.z);

        //transform.localEulerAngles = new Vector3(10f, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
