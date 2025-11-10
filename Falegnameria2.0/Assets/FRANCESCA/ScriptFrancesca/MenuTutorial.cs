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
}
