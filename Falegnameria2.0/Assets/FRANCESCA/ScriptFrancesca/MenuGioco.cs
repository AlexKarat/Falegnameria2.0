using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGiocoLegnoManager : MonoBehaviour
{
    // Quando premi START
    public void OnStartButton()
    {
        Debug.Log("Avvio minigioco: MiniGiocoLegna");
        SceneManager.LoadScene("MiniGiocoLegna");
    }

    // Quando premi TUTORIAL
    public void OnTutorialButton()
    {
        Debug.Log("Apro tutorial: MenuTutorialLegno");
        SceneManager.LoadScene("MenuTutorialLegno");
    }

    // Quando premi INDIETRO
    public void OnBackButton()
    {
        Debug.Log("Torno all'hub: hubselection");
        SceneManager.LoadScene("hubselection");
    }
}
