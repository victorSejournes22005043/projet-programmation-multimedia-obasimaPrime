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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger détecté avec : " + other.gameObject.name);
        if (other.gameObject.name == "Lava")
        {
            currentHealth = 0;
            healthbar.SetHealth(currentHealth);
            Debug.Log("Trigger avec Lava : Santé mise à 0 !");
        }
        else if (other.gameObject.name == "Enemy")
        {
            takeDamage(20);
            Debug.Log("Trigger avec Lava : Santé mise à 0 !");
        }
    }



}
