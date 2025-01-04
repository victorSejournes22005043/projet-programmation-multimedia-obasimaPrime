using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject hudPrefab; // Le prefab du HUD
    private static GameObject hudInstance; // Singleton pour éviter les doublons

    void Awake()
    {
        if (hudInstance == null)
        {
            // Crée une instance du HUD
            hudInstance = Instantiate(hudPrefab);
            DontDestroyOnLoad(hudInstance); // Le HUD persiste entre les scènes
        }
        else
        {
            Destroy(gameObject); // Détruit tout HUD supplémentaire
        }
    }
}
