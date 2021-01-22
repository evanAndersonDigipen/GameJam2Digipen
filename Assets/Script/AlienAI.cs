using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAI : MonoBehaviour
{
    private float jumpTimer = 0;
    private float jumpDirection = 1;
    public float jumpDelay = 1;
    public Rigidbody2D rb;
    private Animator anim;
    public float rayDistance;

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
        if (jumpTimer > jumpDelay)
        {
            rb.AddForce(new Vector2(jumpForceX * jumpDirection, jumpForceY));
            jumpDirection *= -1;
            rb.velocity = Vector2.zero;
            jumpTimer = 0;
        }

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

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayDistance + 0.1f);
        if (hit)
            return true;
            return false;
    }
}
