using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public HealthBar healthbar;
    public TMP_Text coinText;

    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }

        coinText.text = "x " + GameManager.instance.GetTotalCoins().ToString();
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
        if (other.gameObject.CompareTag("Lava"))
        {
            currentHealth = 0;
            healthbar.SetHealth(currentHealth);
            Debug.Log("Trigger avec Lava : Santé mise à 0 !");
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            takeDamage(20);
            Debug.Log("Trigger avec Lava : Santé mise à 0 !");
        }
    }
}
