//By: Dhruv Darbha
//Date: 1/13/2021
//Desc: Damage the asteriod and player with this

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageOnCollide1 : MonoBehaviour
{
    public int Damage = 10;
    public bool DestroyOnCollide = true;
    public UnityEvent OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        if (OnDeath == null)
        {
            OnDeath = new UnityEvent();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //check for health on other object, if there apply damage
        //Health otherHealth = collision.gameObject.GetComponent<Health>();
        //if we destroy ourselves do that
        if (DestroyOnCollide)
        {
            OnDeath.Invoke();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
