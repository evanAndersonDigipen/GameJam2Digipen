////////////////////////////
/// By: Gavin C
/// Date: 1/6/2021
/// Desription: Add this to a object with a kinematic rigidbody, set the waypoints for it to go to
///////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingObject : MonoBehaviour
{
    [Tooltip("The locations the object will go to. (0, 0, 0 is the starting point and all other points are relative)")]
    public Vector3[] Waypoints = { Vector3.zero, new Vector3(4, 0, 0) };
    [Tooltip("The speed the object will move. (1 is 1 unit per second)")]
    public float Speed = 1;
    [Tooltip("What is close enough to a point to count as being on the point.")]
    public float CloseEnough = 0.1f;


    int CurrentWaypoint = 0;
    Vector3 DirrectionToWaypoint;


    // Start is called before the first frame update
    void Start()
    {
        //convert waypoints into world space
        for (int i = 0; i < Waypoints.Length; i++)
        {
            Waypoints[i] += transform.position;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //get a vector to next waypoint
        DirrectionToWaypoint = Waypoints[CurrentWaypoint] - transform.position;

        //check if we are close enough
        if (DirrectionToWaypoint.sqrMagnitude < CloseEnough)
        {
            //target next waypoint
            CurrentWaypoint++;

            //reset back to begining of list if needed
            if (CurrentWaypoint >= Waypoints.Length)
            {
                CurrentWaypoint = 0;
            }

            //get a vector to next waypoint
            DirrectionToWaypoint = Waypoints[CurrentWaypoint] - transform.position;
        }

        //normalize vector
        DirrectionToWaypoint.Normalize();

        //move object
        transform.position += DirrectionToWaypoint * Speed * Time.fixedDeltaTime;
    }
}
