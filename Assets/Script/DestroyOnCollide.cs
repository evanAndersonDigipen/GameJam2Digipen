//Name: Eric Lighthall
//Date 1/22/2021
//Desc: Deals with player bullet hit collisions and damaging enemies.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    public AudioSource hitAudio;
    public GameObject hitParticles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "PlayerBullet")
        {
            GameObject particles = Instantiate(hitParticles, transform.position, transform.rotation);
            Destroy(particles, 2);
        }

        if (collision.gameObject.tag == "Death")
        {
            if (collision.gameObject.GetComponent<Health>() != null)
            collision.gameObject.GetComponent<Health>().HealthRemover(2);
        }

        if (hitAudio != null)
        {
            //Disable the sprite renderer
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            hitAudio.Play();
            Destroy(gameObject, hitAudio.clip.length);
        } 
        else
        {
            Destroy(gameObject);
        }
    }
}
