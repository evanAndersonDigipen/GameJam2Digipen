using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipgrav : MonoBehaviour
{
    Rigidbody2D rigid;
    bool upsidedown = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == ("flip"))
        {
            rigid.gravityScale *= -1;
            Flipbody();
        }
    }
    void Flipbody()
    {
        // Switch the way the player is labelled as facing
        upsidedown = !upsidedown;

        // Multiply the player's x local scale by -1
        Vector3 Scale = transform.localScale;
        Scale.y *= -1;
        transform.localScale = Scale;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
