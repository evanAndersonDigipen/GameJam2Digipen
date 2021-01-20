using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 10;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void HealthRemover(float damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            deathEvent();
        }
    }

    private void deathEvent()
    {
        //Do death stuff here
        Destroy(gameObject);
    }
}
