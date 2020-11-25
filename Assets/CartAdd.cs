using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartAdd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Call add to cart when object enters physical cart
        GameObject.Find("Character").GetComponent<GrabSystem>().AddToCart(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        //Call remove from cart when object leaves physical cart
        GameObject.Find("Character").GetComponent<GrabSystem>().RemoveFromCart(other.gameObject);
    }
}
