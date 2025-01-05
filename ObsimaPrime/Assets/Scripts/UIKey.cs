using UnityEngine;
using UnityEngine.UI;

public class UIKeyVisibility : MonoBehaviour
{
    public GameObject uiElement;

    void Update()
    {
        if (GameManager.instance != null)
        {
            uiElement.SetActive(GameManager.instance.HasKey);
        }
    }
}
