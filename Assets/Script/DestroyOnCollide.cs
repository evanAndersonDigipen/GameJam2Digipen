using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    public AudioSource hitAudio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hitAudio != null)
        {
            //Disable the sprite renderer
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            hitAudio.Play();
            Destroy(gameObject, hitAudio.clip.length);
        } 
        else
        {
            Destroy(gameObject);
        }
    }
}
