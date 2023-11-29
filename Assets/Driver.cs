using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float defaultSpeed = 10f;
    [SerializeField] float grassSpeed = 8f;
    [SerializeField] float boostSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * defaultSpeed * Time.deltaTime;
        // transform.Translate(0, 0.01f, 0);
        transform.Translate(0, moveAmount, 0);
        if (moveAmount > 0 | moveAmount < -0) {
            transform.Rotate(0, 0, -steerAmount);
        } 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        defaultSpeed = grassSpeed;
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if (other.tag == "Boost")
    //     {
    //         defaultSpeed = boostSpeed;
    //     }

    //     if (other.tag == "Road")
    //     {
    //         defaultSpeed = 10f;
    //     } 
    // }


    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Boost") 
        {
            defaultSpeed = boostSpeed;
        } 
        else if (other.tag == "Road") 
        {
            defaultSpeed = 10f;
        } 
        else if (other.tag == "Grass")
        {
            Debug.Log("You're in grass");
            defaultSpeed = grassSpeed;
        }
    }


    // private void OnTriggerExit2D(Collider2D other) {
    //     defaultSpeed = grassSpeed;
    // }
}
