using UnityEngine;
using UnityEngine.UI;

public class UIKeyVisibility : MonoBehaviour
{
    public GameObject uiElement; // L'élément de l'UI que tu veux rendre visible/invisible

    void Update()
    {
        if (GameManager.instance != null)
        {
            // Change la visibilité en fonction de la valeur de HasKey
            uiElement.SetActive(GameManager.instance.HasKey);
        }
    }
}
