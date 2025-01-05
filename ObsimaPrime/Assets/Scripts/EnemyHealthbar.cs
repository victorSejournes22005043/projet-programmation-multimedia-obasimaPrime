using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform target; // La tête ou le centre de l'ennemi
    public Vector3 offset = new Vector3(0, 2, 0); // Décalage vertical au-dessus de l'ennemi

    private Camera mainCamera;

    void Start()
    {
        // Récupère la caméra principale
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (target != null && mainCamera != null)
        {
            // Convertit la position de l'ennemi dans l'espace écran
            transform.position = mainCamera.WorldToScreenPoint(target.position + offset);
        }
    }
}
