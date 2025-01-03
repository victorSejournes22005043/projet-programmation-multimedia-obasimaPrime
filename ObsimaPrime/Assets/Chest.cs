using UnityEngine;
using System.Collections; // N�cessaire pour utiliser les coroutines

public class Chest : MonoBehaviour
{
    public GameObject coinPrefab; // L'objet qui appara�t (par ex. une pi�ce)
    public Transform spawnPoint; // Point o� l'objet appara�tra
    private Animator animator;   // L'Animator du coffre
    private bool isOpen = false;

    private void Start()
    {
        // R�cup�rer l'Animator attach� au coffre
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance.HasKey && !isOpen)
        {
            Debug.Log("Coffre ouvert !");
            StartCoroutine(OpenChestCoroutine()); // Lancer la coroutine
        }
        else if (other.CompareTag("Player") && !GameManager.instance.HasKey)
        {
            Debug.Log("Le joueur a besoin de la cl� pour ouvrir ce coffre !");
        }
    }

    private IEnumerator OpenChestCoroutine()
    {
        isOpen = true;

        // D�clenche l'animation d'ouverture
        animator.SetBool("isOpen", true);

        // Attendre la fin de l'animation
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Apparition de l'objet (par ex. une pi�ce)
        if (coinPrefab != null && spawnPoint != null)
        {
            coinPrefab.transform.position = spawnPoint.position;
        }
    }
}
