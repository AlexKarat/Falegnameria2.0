using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTutorialLegno : MonoBehaviour
{
    // Quando premi il pulsante INDIETRO
    public void OnBackButton()
    {
        Debug.Log("Torno al menu del minigioco legno");
        SceneManager.LoadScene("MenuGiocoLegno");
    }

    public void OnBackSega()
    { 
        Debug.Log("Torno al menu del tutorial sega");
        SceneManager.LoadScene("MenuGiocoSega");
    }
}
