using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton pour un accès global

    private int totalCoins = 0; // Nombre total de pièces collectées

    public bool HasKey = false; // Le jouer possède une clé


    private void Awake()
    {
        // Configure le GameManager comme singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Garde le GameManager entre les scènes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Méthode pour ajouter des pièces
    public void AddCoins(int amount)
    {
        totalCoins += amount;
        Debug.Log("Total Coins: " + totalCoins);

        // Optionnel : Mettre à jour l'UI
        // UIManager.instance.UpdateCoinUI(totalCoins);
    }

    // Accesseur pour obtenir le nombre total de pièces
    public int GetTotalCoins()
    {
        return totalCoins;
    }
}
