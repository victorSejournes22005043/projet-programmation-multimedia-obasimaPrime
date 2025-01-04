using UnityEngine;
using UnityEngine.SceneManagement; // Pour charger les scènes

public class MainMenu : MonoBehaviour
{
    // Méthode appelée lorsque le joueur clique sur "Jouer"
    public void PlayGame()
    {
        // Charger la scène du jeu (index ou nom de la scène)
        SceneManager.LoadScene("SampleScene");
    }

    // Méthode appelée lorsque le joueur clique sur "Quitter"
    public void QuitGame()
    {
        // Quitter l'application
        Debug.Log("Quitter le jeu"); // Fonctionne uniquement dans l'éditeur
        Application.Quit();
    }
}
