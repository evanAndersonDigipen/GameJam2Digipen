﻿////////////////////////////
/// By: Gavin C
/// Date: 1/7/2021
/// Desription: Use on object that will be destroyed when touched by player, adding to the score
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScore : MonoBehaviour
{
    [Tooltip("The amount of points you get from collecting object")]
    public int Points = 1;


    //destroy and add points if collide with player
    private void OnTriggerEnter2D (Collider2D collision)
    {        
        if (collision.CompareTag("Player"))
        {
            GameManager.Score += Points;
            Destroy(gameObject);
        }
    }
}
