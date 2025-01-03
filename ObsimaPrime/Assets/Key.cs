using UnityEngine;

public class Key : MonoBehaviour
{
    public float floatSpeed = 1f; // Vitesse de mont�e/descente
    public float floatHeight = 0.5f; // Amplitude du flottement

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Animation de flottement
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Cl� r�cup�r�e !");
            GameManager.instance.HasKey = true; // Indiquer que le joueur a la cl�
            Destroy(gameObject); // Supprimer la cl�
        }
    }
}
