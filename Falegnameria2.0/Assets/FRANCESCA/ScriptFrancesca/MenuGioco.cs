using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGiocoLegnoManager : MonoBehaviour
{
    // Quando premi START legno
    public void OnStartButton()
    {
        Debug.Log("Avvio minigioco: MiniGiocoLegna");
        SceneManager.LoadScene("MiniGiocoLegna");
    }

    // Quando premi TUTORIAL legno
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

    public void OnTutorialSega()
        {
        Debug.Log("Apro tutorial sega: MenuTutorialSega");
        SceneManager.LoadScene("MenuTutorialSega");
    }

    public void OnStartSega()
    {
        Debug.Log("Avvio minigioco: MiniGiocoSega");
        SceneManager.LoadScene("MiniGiocoSegaCircolare");
    }
}
