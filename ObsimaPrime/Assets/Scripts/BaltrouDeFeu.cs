using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaltrouDeFeu : MonoBehaviour
{
    public ParticleSystem fireParticles;  
    public float damage = 10f;           
    public float radius = 5f;            
    public float cooldown = 2f;          
    public float particleDuration = 1f;  

    private bool canAttack = false;      
    private bool hasPickedUpPepper = false; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canAttack && hasPickedUpPepper)
        {
            StartCoroutine(PerformFireAttack());
        }

    }

    private IEnumerator PerformFireAttack()
    {
        canAttack = false; // Bloque l'attaque pendant le cooldown

        // Active les particules de feu si elles existent
        if (fireParticles != null)
        {
            fireParticles.Play();
            // Arrête les particules après une durée spécifiée
            StartCoroutine(StopParticlesAfterDuration());
        }
        else
        {
            Debug.LogWarning("Les particules de feu ne sont pas assignées !");
        }

        // Détecte les ennemis dans le rayon
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hitCollider in hitColliders)
        {
            // Récupère le script Enemy sur l'objet touché
            Enemy enemyScript = hitCollider.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(damage);
            }
        }

        // Attends le cooldown avant de réactiver l'attaque
        yield return new WaitForSeconds(cooldown);

        canAttack = true; // Réautorise une nouvelle attaque
    }

    private IEnumerator StopParticlesAfterDuration()
    {
        // Attends la durée spécifiée avant d'arrêter les particules
        yield return new WaitForSeconds(particleDuration);
        if (fireParticles != null && fireParticles.isPlaying)
        {
            fireParticles.Stop();
        }
    }

    // Fonction pour ramasser le piment
    public void PickUpPepper()
    {
        hasPickedUpPepper = true; 
        canAttack = true; 
        Debug.Log("Piment ramassé ! Tu peux maintenant cracher du feu !");
    }

    // Affiche le rayon dans l'éditeur pour visualiser l'AOE
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
