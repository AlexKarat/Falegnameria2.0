using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButtonsManager : MonoBehaviour
{
    [Header("Nomi delle Scene")]
    public string menuSceneName = "MainMenu";   // scena del menù (puoi cambiarlo in seguito)
    public string hubSceneName = "Hub";         // scena dell’hub (puoi cambiarlo in seguito)
    public string miniGiocoSceneName = "MiniGiocoLegna"; // 👈 aggiunto per restart

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
        UnityEditor.EditorApplication.isPlaying = false; // così funziona anche in Play Mode
#endif
    }
}
