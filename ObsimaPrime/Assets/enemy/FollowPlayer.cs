using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player; // Le joueur à suivre
    public float speed = 2f; // Vitesse de déplacement

    // Update est appelé à chaque frame
    void Update()
    {
        if (player != null)
        {
            // Calcule la direction vers le joueur
            Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;

            // Déplace l'ennemi vers le joueur
            transform.position += directionToPlayer * speed * Time.deltaTime;
        }
    }
}
