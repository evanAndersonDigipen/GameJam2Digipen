/////////////////////////////////////
///By: Gavin C
///Date: 12/17/2020
///Description: This is a sript to be attached to an object with a trigger collider to go to a new scene
///Using: Make sure the player character rigidbody2d is set to never go to sleep
/////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    [Tooltip("Name of the scene you want this script to load")]
    public string SceneName;
    [Tooltip("Time before it changes scene.")]
    public float Delay = 0.5f;

    //on collide start coroutine if player is pressing interact key
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey("e"))
        {
            if (other.GetComponent<Transform>().tag == "Player")
            {
                StartCoroutine(ChangeScene());
            }
        }
    }

    //change scene
    IEnumerator ChangeScene()
    {
        yield return (new WaitForSeconds(Delay));
        SceneManager.LoadScene(SceneName);
    }
}
