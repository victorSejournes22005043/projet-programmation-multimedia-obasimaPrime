using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthbar;
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            takeDamage(20);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    void Die()
    {
        Debug.Log("Le personnage est mort !");
        FindObjectOfType<DeathHandler>().TriggerDeathScreen();
    }
}
