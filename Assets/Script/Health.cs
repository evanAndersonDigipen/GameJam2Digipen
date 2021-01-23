//Name: Eric Lighthall
//Date: 1/22/2021
//Desc: Updates health on enemies and destroys enemies if health is 0.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 10;
    private float currentHealth;
    public GameObject deathParticles;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void HealthRemover(float damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deathEvent();
        }
    }

    private void deathEvent()
    {
        //Do death stuff here
        if(gameObject.GetComponent<AudioSource>() != null)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        if(deathParticles != null)
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
        }
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 3);
    }
}
