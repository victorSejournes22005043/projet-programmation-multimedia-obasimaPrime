using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour
{
    public GameObject spawnObject; 
    private Animator animator;
    private bool isOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.instance.HasKey && !isOpen)
        {
            Debug.Log("Coffre ouvert !");
            StartCoroutine(OpenChestCoroutine());
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
        if (spawnObject != null)
        {
            spawnObject.SetActive(true);
        }
    }
}
