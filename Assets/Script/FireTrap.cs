////////////////////////////
/// By: Gavin C
/// Date: 1/12/2021
/// Desription: Use on with a polygon trigger and a particle system child to turn them on and off
/// IMPORTANT: the particles will be stay on for how long their durration is in the particle system
///////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireTrap : MonoBehaviour
{
    [Tooltip("The particle system for the fire.")]
    public ParticleSystem Fire;
    [Tooltip("The game object for the pre-fire.")]
    public GameObject PreFireObject;
    [Tooltip("Time spent till start in seconds.")]
    public float TimeTillStart = 1;
    [Tooltip("Time spent OFF in seconds")]
    public float TimeOff = 5;

    float PreFireTime;
    float TimeOn;

    PolygonCollider2D HitBox;
    ParticleSystem PreFire;


    // Start is called before the first frame update
    void Start()
    {   
        //initialize the collider and particle system timers
        HitBox = GetComponent<PolygonCollider2D>();
        PreFire = PreFireObject.GetComponent<ParticleSystem>();
        HitBox.enabled = false;
        PreFireTime = PreFire.main.duration;
        TimeOn = Fire.main.duration;
     
        //start the loop of ON & OFF
        Invoke("PreFireOn", TimeTillStart);
    }

    //Turn pre-fire on
    void PreFireOn()
    {
        //play pre-fire
        PreFire.Play();

        //start next function in some time
        Invoke("FireOn", PreFireTime);
    }

    //Turn fire on
    void FireOn()
    {
        //enable fire
        HitBox.enabled = true;
        Fire.Play();

        //disable pre-fire and turn back on
        PreFireObject.SetActive(false);
        PreFireObject.SetActive(true);

        //start next function in some time
        Invoke("FireOff", TimeOn);
    }

    //Turn fire off
    void FireOff ()
    {
        //disable fire
        HitBox.enabled = false;

        //start next function in some time
        Invoke("PreFireOn", TimeOff);
    }


}