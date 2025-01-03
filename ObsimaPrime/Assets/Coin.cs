using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip pickupSound;

    public int coinValue = 1; // Valeur de la pi�ce (par d�faut 1)

    // D�tecter les collisions avec le joueur
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si c'est le joueur qui touche la pi�ce
        if (other.CompareTag("Player"))
        {
            // Ajoute la valeur de la pi�ce au score
            GameManager.instance.AddCoins(coinValue);

            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            // D�truit la pi�ce apr�s la r�cup�ration
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

}
