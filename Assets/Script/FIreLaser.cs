//By: Dhruv Darbha
//Date: 1/13/2021
//Desc: Add this to player to fire projectiles

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class FIreLaser : MonoBehaviour
{
    [Tooltip("The prefab to be fired, make sure there is a RigidBody 2d")]
    public GameObject Projectile;
    [Tooltip("The speed to set the projectile to")]
    public float ProjectileSpeed = 10;
    [Tooltip("The minimum time between firing in seconds")]
    public float Cooldown = 0.5f;
    float Timer = 0;
    // Start is called before the first frame update
    UnityEvent OnShoot = new UnityEvent();
    public float ShakeTime = 0.1f;
    public float ShakeMag = 20;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Update Timer
        Timer += Time.deltaTime;
        //Check for button press
        //if (Input.GetAxisRaw("Jump") > 0)
        if (Input.GetKeyDown("up"))
        {
            if (Timer >= Cooldown)
            {
                Timer = 0;
                Fire(transform.position, transform.right);
                OnShoot.Invoke();
                //CameraShake.TriggerShake(ShakeTime, ShakeMag);
            }
        }

    }

    void Fire(Vector3 position, Vector3 direction)
    {
        //create the object and store a link to it to set the velocity
        GameObject proj = Instantiate<GameObject>(Projectile, position, transform.rotation);
        //set velocity
        proj.GetComponent<Rigidbody2D>().velocity = direction * ProjectileSpeed;
    }
}
