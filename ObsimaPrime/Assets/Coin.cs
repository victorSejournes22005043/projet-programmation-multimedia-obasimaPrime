using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip pickupSound;

    public int coinValue = 1; // Valeur de la pièce (par défaut 1)

    // Détecter les collisions avec le joueur
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le joueur qui touche la pièce
        if (other.CompareTag("Player"))
        {
            // Ajoute la valeur de la pièce au score
            GameManager.instance.AddCoins(coinValue);

            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            // Détruit la pièce après la récupération
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

}
