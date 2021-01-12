/////////////////////////////////////
///By: Gavin C
///Date: 1/8/2021
///Description: This is a script to be put on an object that needs to rotate
/////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateObject : MonoBehaviour
{
    [Tooltip("How many degrees the object will rotate per second.")]
    public float RotationSpeed = 60;


    // Update is called once per frame
    void Update()
    {
        //Change rotation by RotationSpeed every second
        transform.Rotate (0, 0, RotationSpeed * Time.deltaTime);
    }
}