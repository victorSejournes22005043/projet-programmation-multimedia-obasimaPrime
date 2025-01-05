using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip pickupSound;

    public int coinValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Check si c'est le joueur qui touche la pièce
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddCoins(coinValue);

            // Joue le bruit de pièce
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
