using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] GameObject packageBubble;
    [SerializeField] PlayerVariables playerVar;
    [SerializeField] PackageBubble bubble;

    //int hasPackage; //use this instead of bool to allow multiple package pickups
    

    // [SerializeField] GameObject packageBubble;
    // void LateUpdate()
    // {
    //     packageBubble.transform.position = new Vector3 (3, 0, 0); // syntax for the camera to follow the car 
    // } 

    // void OnCollisionEnter2D(Collision2D other) 
    // {
    //     Debug.Log("Walls can't stop me because I can't read");
    // }

    // void update()
    // {
        
    // }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //Debug.Log("Zoomies"); old code

        if (other.tag == "Package" && !playerVar.hasPackage)  // player goes to package with none on hand
        {
            playerVar.hasPackage = true; //references hasPackage variable from PlayerVariable script and changes it to true
            Debug.Log("Packaged picked up!");
            Destroy(other.gameObject, destroyDelay); //destroy the package game object referenced using other as the argument
            packageBubble.GetComponent<Renderer>().enabled = true;
        } 
        else if (other.tag == "Package" && playerVar.hasPackage)
        {
            bubble.shakeBubble();  
        }
        else if (other.tag == "Customer" && playerVar.hasPackage) // player delivers package to costumer
        {
            Debug.Log("Package delivered!");
            playerVar.hasPackage = false;
            packageBubble.GetComponent<Renderer>().enabled = false;
        } 
        else  //player goes to costumer but has no package
        {
            Debug.Log("You have no packages to deliver"); 
        }

        // code to allow player to collect more than one package
        // if (other.tag == "Package")  
        // {
        //     hasPackage += 1;
        //     Debug.Log("Packaged picked up! (" + hasPackage +")");
        //     Destroy(other.gameObject, destroyDelay);
        // } 
        // else if (other.tag == "Customer" && hasPackage > 0)
        // {
        //     if (hasPackage == 1) {
        //         Debug.Log(hasPackage + " package delivered!");
        //     }
        //     else {
        //         Debug.Log(hasPackage + " packages delivered!");
        //     }
        //     hasPackage = 0;
        // }
        // else {
        //     Debug.Log("You have no packages to deliver");
        // }
        // if (other.tag == "Car") 
        // {
        //     Debug.Log("Is this a car?");
        // }
    }

}
