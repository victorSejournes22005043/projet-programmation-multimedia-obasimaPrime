using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement
    public float gravity = 9.81f; // Gravit�
    private CharacterController controller; // R�f�rence au CharacterController
    private Vector3 velocity; // Vecteur pour g�rer la gravit�
    private bool isGrounded;

    void Start()
    {
        // R�cup�rer le CharacterController attach� au GameObject
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // V�rifier si le personnage est au sol
        isGrounded = controller.isGrounded;

        // Si le personnage est au sol et qu'il tombe, on r�initialise la v�locit� verticale
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Petite valeur n�gative pour maintenir au sol
        }

        // Obtenir les entr�es de l'utilisateur (ZQSD ou fl�ches)
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou fl�ches gauche/droite
        float vertical = Input.GetAxis("Vertical"); // Z/S ou fl�ches haut/bas

        // Cr�er un vecteur de direction bas� sur les entr�es clavier
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // Convertir la direction en coordonn�es locales
        direction = transform.TransformDirection(direction);

        // D�placer le personnage en fonction des touches (zqsd)
        controller.Move(direction * moveSpeed * Time.deltaTime);

        // Appliquer la gravit�
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}


