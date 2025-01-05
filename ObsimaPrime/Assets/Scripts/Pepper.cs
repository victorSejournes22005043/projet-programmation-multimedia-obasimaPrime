using UnityEngine;

public class Pepper : MonoBehaviour
{
    public float floatSpeed = 1f; // Vitesse de montée/descente
    public float floatHeight = 0.5f; // Amplitude du flottement

    private Vector3 startPosition;

    void Start()
    {
        // Sauvegarde la position initiale de Pepper
        startPosition = transform.position;
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }

        private void OnTriggerEnter(Collider other)
    {
        // Vérifie si le joueur entre en collision avec le piment
        if (other.CompareTag("Player"))
        {
            // Récupère le script "BaltrouDeFeu" sur le joueur
            BaltrouDeFeu fireScript = other.GetComponent<BaltrouDeFeu>();
            if (fireScript != null)
            {
                fireScript.PickUpPepper(); // Permet au joueur de cracher du feu
                Destroy(gameObject); // Détruit le piment après l'avoir ramassé
            }
        }
    }
}
