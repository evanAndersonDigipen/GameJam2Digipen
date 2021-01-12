/////////////////////////////////////
///By: Gavin C
///Date: 1/7/2020
///Description: This is a 2D playercontroller with dynamic jumping, multi-jumping, also includes animation
///Using: To be used with WallCollider & GroundCollider script, animator must be set up, must have sound source
///https://youtu.be/QGDeafTx5ug
///https://youtu.be/j111eKN8sJw
/////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Tooltip("The horizontal movement speed of the character.")]
    public float MovementSpeed = 5;
    [Tooltip("The speed the chracter will accelerate to max speed.")]
    public float Acceleration = 2;

    [Tooltip("The force the player will jump with.")]
    public float JumpForce = 5;

    [Tooltip("The amount of time you can hold down space to jump higher.")]
    public float JumpTime = 0.2f;
    [Tooltip("The amount of extra jumps that can be made in the air.")]
    public int ExtraJumps = 1;

    [Tooltip("The jump sound.")]
    public AudioClip JumpSound;

    Rigidbody2D PlayerRB;
    Animator PlayerAnim;
    AudioSource MyAudio;

    int Dirrection = 0;
    bool FacingRight = true;

    [Tooltip("For Script Use")]
    public bool IsGrounded = false;
    int ExtraJumpsCounter;
    bool IsJumping = false;
    float JumpTimeCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerAnim = GetComponent<Animator>();
        MyAudio = GetComponent<AudioSource>();
        ExtraJumpsCounter = ExtraJumps;
    }


    // Update is called once per frame
    void Update()
    {
        //Figure out dirrection tried to move in most recently
        if (Input.GetKeyDown("a"))
        {
            Dirrection = -1;
        }
        else if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            Dirrection = -1;
        }
        else if (Input.GetKeyDown("d"))
        {
            Dirrection = 1;
        }
        else if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            Dirrection = 1;
        }
        else if (Input.GetKey("a") == false && Input.GetKey("d") == false)
        {
            Dirrection = 0;
        }


        //Changes the players horizontal velocity
        PlayerRB.AddForce(new Vector2(Dirrection * Acceleration, 0));

        //stop player velocity from being too fast
        if ((PlayerRB.velocity.x > Dirrection * MovementSpeed && Dirrection > 0) || (PlayerRB.velocity.x < Dirrection * MovementSpeed && Dirrection < 0))
        {
            PlayerRB.velocity = new Vector2(Dirrection * MovementSpeed, PlayerRB.velocity.y);
        }


        //slow down player if standing still
        if (Dirrection == 0 && IsGrounded)
        {
            PlayerRB.velocity = Vector3.Lerp(PlayerRB.velocity, new Vector3(0, 0, 0), 0.05f);
        }


        //Flip character
        if (FacingRight == false && Dirrection > 0)
        {
            Flip();
        }
        else if (FacingRight == true && Dirrection < 0)
        {
            Flip();
        }


        //Give extra jumps back
        if (IsGrounded == true)
        {
            ExtraJumpsCounter = ExtraJumps;
        }

        //Jump if key space is down and they are on ground OR have extra jumps
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, Vector2.up.y * JumpForce);
            JumpTimeCounter = 0;
            IsJumping = true;
            MyAudio.PlayOneShot(JumpSound);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && ExtraJumpsCounter > 0)
        {
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, Vector2.up.y * JumpForce);
            ExtraJumpsCounter--;
            JumpTimeCounter = 0;
            IsJumping = true;
            MyAudio.PlayOneShot(JumpSound);
        }

        //Let the player keep jumping if they havent let up the space bar
        if (Input.GetKey(KeyCode.Space) && IsJumping == true)
        {
            //Lets you keep jumping if time hasn't run out
            if (JumpTimeCounter < JumpTime)
            {
                PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, Vector2.up.y * JumpForce);
                JumpTimeCounter += Time.deltaTime;
            }
            else
            {
                IsJumping = false;
            }
        }

        //Stops higher jump when space is no longer being pressed
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsJumping = false;
        }


        //Setting animations variable grounded
        PlayerAnim.SetBool("IsGrounded", IsGrounded);

        //Setting animations variable walking
        if (Dirrection == 0)
        {
            PlayerAnim.SetBool("IsWalking", false);
        }
        else
        {
            PlayerAnim.SetBool("IsWalking", true);
        }
    }


    //Function to flip character by reversing its scaler
    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
