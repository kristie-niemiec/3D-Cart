using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isDragged = false;
    

    // Update is called once per frame
    void Update()
    {
        if (isDragged == true)
            gameObject.transform.position = Input.mousePosition;
    }

    public void StartPickup()
    {
        isDragged = true;
    }

    public void EndPickup()
    {
        isDragged = false;
    }
}
