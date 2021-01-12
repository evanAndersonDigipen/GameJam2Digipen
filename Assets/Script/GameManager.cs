////////////////////////////
/// By: Gavin C
/// Date: 1/7/2021
/// Desription: Use to store variable used in between levels
///////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    //variables
    private static int score = 0;


    //Events to be listened to
    public static UnityEvent OnVariablesUpdate = new UnityEvent();


    //variable properties
    public static int Score
    {
        get => score;
        set
        {
            score = value;
            OnVariablesUpdate.Invoke();
        }
    }
}
