using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform teleportLocation; // La position où le joueur sera téléporté

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre dans la hitbox a le tag "Player"
        if (other.CompareTag("Player"))
        {
            // Téléporte le joueur à la nouvelle position
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = teleportLocation.position;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
