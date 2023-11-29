using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
   
    [SerializeField] GameObject playerCar;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerCar.transform.position + new Vector3 (0, 0, -20); // syntax for the camera to follow the car 
    }
}
