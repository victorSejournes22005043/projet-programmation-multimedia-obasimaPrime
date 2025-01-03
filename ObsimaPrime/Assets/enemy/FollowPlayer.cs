using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; // Le joueur � suivre
    public float speed = 2f; // Vitesse de d�placement

    // Update est appel� � chaque frame
    void Update()
    {
        if (player != null)
        {
            // Calcule la direction vers le joueur
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

            // D�place l'ennemi vers le joueur
            transform.position += directionToPlayer * speed * Time.deltaTime;
        }
    }
}
