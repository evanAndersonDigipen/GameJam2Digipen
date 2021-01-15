//Name: Eric Lighthall
//Date: 1/12/2021
//Desc: Spawns a bullet prefab that moves in the direction where the player clicked.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    private Vector3 mousePosition;      //Position of mouse
    public GameObject BulletPrefab;     //Prefab to spawn in
    public float bulletSpeed = 10f;     //Speed of bullet
    public float shootDelay = .1f;
    private float shootTimer;
    public GameObject spawnPosition;

    // Update is called once per frame
    void Update()
    {
        shootTimer += Time.deltaTime;
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        if (Input.GetMouseButton(0) && shootTimer > shootDelay)
        {
            WeaponShoot();
            shootTimer = 0f;
        }
    }

    private void WeaponShoot()
    {
        //Get the vector between the mouse position and player
        Vector2 difference = mousePosition - transform.position;
        //gets the diagonal component of the vector
        Vector2 shootDirection = (difference / difference.magnitude);
        //Normalize so direction does not interfere with velocity of the bullet
        shootDirection.Normalize();

        //Instantiate new bullet
        GameObject newBullet = Instantiate(BulletPrefab, spawnPosition.transform.position, transform.rotation);
        //Set velocity to the vector * speed
        newBullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
        //Set rotation of bullet to look at the mouse
        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        newBullet.transform.rotation = Quaternion.Euler(0, 0, rotation);

        if (newBullet != null)
        {
            Destroy(newBullet, 2);
        }
    }
}
