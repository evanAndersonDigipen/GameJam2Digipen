/////////////////////////////////////
///By: Gavin C
///Date: 12/16/2020
///Description: This is the PlayerLogic of a 2D game
/////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [Tooltip("Color of active checkpoint.")]
    public Color ActiveCheckpoint = new Color(0, 1, 0, 1);
    [Tooltip("Color of inactive checkpoint.")]
    public Color InactiveCheckpoint = new Color(1, 1, 1, 1);

    private Vector3 RespawnPos;
    private GameObject LastCheckpoint;

    // Start is called before the first frame update
    void Start()
    {
        RespawnPos = transform.position;
    }

    //On collide check what the player collided with
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check if player should die
        if (collision.gameObject.CompareTag("Death"))
        {   
            transform.position = RespawnPos;
        }
        //check if player should attach to object
        else if (collision.gameObject.CompareTag("Moving"))
        {
            transform.SetParent(collision.transform);
        }
    }

    //Check if player needs un-attach from object
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moving"))
        {
            transform.SetParent(null);
        }
    }

    //On collide check if player should get checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            RespawnPos = transform.position;

            //set colors of checkpoints
            if (LastCheckpoint != null)
            {
                LastCheckpoint.GetComponent<SpriteRenderer>().color = InactiveCheckpoint;
            }
            collision.GetComponent<SpriteRenderer>().color = ActiveCheckpoint;

            //save current checkpoint to use later
            LastCheckpoint = collision.gameObject;
        }
    }
}
