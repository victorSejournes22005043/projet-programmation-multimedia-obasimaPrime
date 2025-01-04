using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    public TMP_Text coinText; // Référence au texte UI où afficher les pièces

    void Start()
    {
        // Mettre à jour le texte avec le nombre total de pièces
        coinText.text = "Total Coins: " + GameManager.instance.GetTotalCoins().ToString();
        GameManager.instance.ResetCoins();
    }
}