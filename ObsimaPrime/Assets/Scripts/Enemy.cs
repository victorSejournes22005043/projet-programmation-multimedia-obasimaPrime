using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 50f; // Vie maximale de l'ennemi
    private float currentHealth;

    void Start()
    {
        // Initialisation de la vie de l'ennemi
        currentHealth = maxHealth;
    }

    // Méthode pour infliger des dégâts
    public void TakeDamage(float amount)
    {
        Debug.Log(gameObject.name + " prend " + amount + " dégâts !");

        currentHealth -= amount; // Réduit la vie de l'ennemi

        if (currentHealth <= 0)
        {
            Die(); // L'ennemi meurt si sa vie tombe à 0
        }
    }

    // Méthode appelée quand l'ennemi meurt
    private void Die()
    {
        Debug.Log(gameObject.name + " est mort !");
        Destroy(gameObject); // Détruit l'objet de l'ennemi
    }
}
