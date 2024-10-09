using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement
    public float gravity = 9.81f; // Gravité
    private CharacterController controller; // Référence au CharacterController
    private Vector3 velocity; // Vecteur pour gérer la gravité
    private bool isGrounded;

    void Start()
    {
        // Récupérer le CharacterController attaché au GameObject
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Vérifier si le personnage est au sol
        isGrounded = controller.isGrounded;

        // Si le personnage est au sol et qu'il tombe, on réinitialise la vélocité verticale
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Petite valeur négative pour maintenir au sol
        }

        // Obtenir les entrées de l'utilisateur (ZQSD ou flèches)
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou flèches gauche/droite
        float vertical = Input.GetAxis("Vertical"); // Z/S ou flèches haut/bas

        // Créer un vecteur de direction basé sur les entrées clavier
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // Convertir la direction en coordonnées locales
        direction = transform.TransformDirection(direction);

        // Déplacer le personnage en fonction des touches (zqsd)
        controller.Move(direction * moveSpeed * Time.deltaTime);

        // Appliquer la gravité
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}


