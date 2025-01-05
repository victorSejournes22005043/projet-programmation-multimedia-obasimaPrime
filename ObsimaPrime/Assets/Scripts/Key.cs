using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioClip pickupSound;

    public float floatSpeed = 1f;
    public float floatHeight = 0.5f;

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
            Debug.Log("Clé récupéré par le joueur");
            GameManager.instance.HasKey = true; // Indiquer que le joueur a la clé

            AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            Destroy(gameObject); // Supprimer la clé
        }
    }
}
