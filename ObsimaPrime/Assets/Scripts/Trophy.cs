using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{
    public float floatAmplitude = 0.5f; // Amplitude du flottement
    public float floatSpeed = 2f; // Vitesse du flottement

    private float baseY; // Position de référence pour le flottement

    void Start()
    {
        // Initialiser la position de référence en Y
        baseY = transform.position.y;
    }

    void Update()
    {
        // Faire tourner le trophée
        transform.Rotate(0, 50 * Time.deltaTime, 0);

        // Faire flotter l'objet autour de la position de référence
        float newY = baseY + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assure-toi que ton joueur a le tag "Player"
        {
            // Charger la scène de victoire
            SceneManager.LoadScene("VictoryScreen");
        }
    }
}
