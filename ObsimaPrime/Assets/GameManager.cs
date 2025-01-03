using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton pour un acc�s global

    private int totalCoins = 0; // Nombre total de pi�ces collect�es

    public bool HasKey = false; // Le jouer poss�de une cl�


    private void Awake()
    {
        // Configure le GameManager comme singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Garde le GameManager entre les sc�nes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // M�thode pour ajouter des pi�ces
    public void AddCoins(int amount)
    {
        totalCoins += amount;
        Debug.Log("Total Coins: " + totalCoins);

        // Optionnel : Mettre � jour l'UI
        // UIManager.instance.UpdateCoinUI(totalCoins);
    }

    // Accesseur pour obtenir le nombre total de pi�ces
    public int GetTotalCoins()
    {
        return totalCoins;
    }
}
