using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform teleportLocation; // La position o� le joueur sera t�l�port�

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet qui entre dans la hitbox a le tag "Player"
        if (other.CompareTag("Player"))
        {
            // T�l�porte le joueur � la nouvelle position
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = teleportLocation.position;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
