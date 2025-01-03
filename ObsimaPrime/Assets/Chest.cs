using UnityEngine;
using System.Collections; // Nécessaire pour utiliser les coroutines

public class Chest : MonoBehaviour
{
    public GameObject coinPrefab; // L'objet qui apparaît (par ex. une pièce)
    public Transform spawnPoint; // Point où l'objet apparaîtra
    private Animator animator;   // L'Animator du coffre
    private bool isOpen = false;

    private void Start()
    {
        // Récupérer l'Animator attaché au coffre
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
            Debug.Log("Le joueur a besoin de la clé pour ouvrir ce coffre !");
        }
    }

    private IEnumerator OpenChestCoroutine()
    {
        isOpen = true;

        // Déclenche l'animation d'ouverture
        animator.SetBool("isOpen", true);

        // Attendre la fin de l'animation
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Apparition de l'objet (par ex. une pièce)
        if (coinPrefab != null && spawnPoint != null)
        {
            coinPrefab.transform.position = spawnPoint.position;
        }
    }
}
