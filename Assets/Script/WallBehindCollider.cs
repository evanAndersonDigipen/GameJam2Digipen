﻿/////////////////////////////////////
///By: Gavin C
///Date: 1/12/2020
///Description: This is a collider script for the 2DPlayerControllerComplex
///Using: The child object needs a trigger, the world needs to have the tag solid world
/////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehindCollider : MonoBehaviour
{
    //set up script variable
    public PlayerController2DComplex Player;

    //collider to see if on wall and set variable
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SolidWorld") || collision.CompareTag("Moving"))
        {
            Player.WallBehind = true;
        }
    }

    private void OnTriggerstay2D(Collider2D collision)
    {
        if (collision.CompareTag("SolidWorld") || collision.CompareTag("Moving"))
        {
            Player.WallBehind = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SolidWorld") || collision.CompareTag("Moving"))
        {
            Player.WallBehind = false;
        }
    }
}
