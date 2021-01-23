//Name: Eric Lighthall
//Date: 1/22/2021
//Desc: Makes aliens jump on a set delay.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAI : MonoBehaviour
{
    private float jumpTimer = 0;
    private float jumpDirection = 1;
    public float jumpDelay = 1; // Time between jumps
    public Rigidbody2D rb;
    private Animator anim;
    public float rayDistance;
    // Jump forces
    public float jumpForceX = 100;
    public float jumpForceY = 100;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump every jumpDelay.
        if (jumpTimer > jumpDelay)
        {
            rb.AddForce(new Vector2(jumpForceX * jumpDirection, jumpForceY));
            jumpDirection *= -1;
            rb.velocity = Vector2.zero;
            jumpTimer = 0;
        }
        //If is grounded, start the jump timer and animate.
        if(isGrounded())
        {
            jumpTimer += Time.deltaTime;
            anim.SetBool("isSquishing", true);
            rb.isKinematic = false;
        }
        else if(!isGrounded())
        {
            anim.SetBool("isSquishing", false);
        }
    }

    //Check if alien is on the ground with a raycast.
    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayDistance + 0.1f);
        if (hit)
            return true;
            return false;
    }
}
