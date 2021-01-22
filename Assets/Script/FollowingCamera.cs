//////////////////
///By: Ryan Scheppler
///Edited By: Gavin C
///Date: 12/16/2020
///Description: This is a script meant to be added to a camera to follow a specified target
//////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [Tooltip("The object the camera will follow.")]
    public GameObject Target;
    [Tooltip("How fast the camera will snap to the player.")]
    public float smoothVal = 0.5f;
    [Tooltip("The offset of the camera compared to the player.")]
    public Vector3 Offset = new Vector3(0, 0, 0);

    //move camera to correct location on start
    void Start()
    {
        transform.position = new Vector3 (Target.transform.position.x + Offset.x, Target.transform.position.y + Offset.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if(Target != null)
        {
            //Figure out where the target is
            Vector3 newPos = Target.transform.position;

            //add the offset
            newPos += Offset;

            //maintain camera z level
            newPos.z = transform.position.z;

            //use linear interpolation to smoothly go to the target
            transform.position = Vector3.Lerp(transform.position, newPos, smoothVal);
        }
    }
}
