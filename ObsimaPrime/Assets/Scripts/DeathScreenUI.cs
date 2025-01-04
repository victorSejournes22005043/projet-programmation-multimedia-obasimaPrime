using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    void Start()
    {
        // Afficher le curseur et libérer le contrôle de la souris
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RetryGame()
    {
        // Charger la scène de jeu principale
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        // Quitter le jeu
        Application.Quit();
        Debug.Log("Jeu quitté !");
    }
}
