using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonsManager : MonoBehaviour
{
    [Header("Nomi delle Scene")]
    public string menuSceneName = "MainMenu";          // Nome della scena del menù
    public string hubSceneName = "hubselection";       // ✅ Nome della scena dell'hub
    public string miniGiocoSceneName = "MiniGiocoLegna"; // Nome della scena del minigioco

    // Torna al menù principale
    public void GoToMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    // Riavvia il minigioco
    public void RestartLevel()
    {
        SceneManager.LoadScene(miniGiocoSceneName);
    }

    // Torna all'hub
    public void GoToHub()
    {
        SceneManager.LoadScene(hubSceneName);
    }

    // Esce dal gioco
    public void QuitGame()
    {
        Debug.Log("Uscita dal gioco");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Funziona anche in Play Mode
#endif
    }
}
