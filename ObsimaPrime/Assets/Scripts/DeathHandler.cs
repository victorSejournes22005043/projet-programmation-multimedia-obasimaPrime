using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathHandler : MonoBehaviour
{
    public void TriggerDeathScreen()
    {
        // Charger la scène de l'écran de défaite
        SceneManager.LoadScene("DeathScreen");
    }
}
