using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodDeath : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 respawnPos;

    void Start()
    {
        respawnPos = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            transform.position = respawnPos;
        }
    }

}
