using UnityEngine;
using UnityEngine.SceneManagement; // Serve per cambiare scena

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject optionsPanel;   // Pannello delle opzioni
    public GameObject dimmer;         // Sfondo scuro dietro le opzioni

    [Header("Scene Settings")]
    public string gameSceneName = "GameScene"; // Nome della scena del gioco

    // === FUNZIONI LEGATE AI PULSANTI ===

    public void StartGame()
    {
        // Carica la scena di gioco
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenOptions()
    {
        // Attiva pannello e dimmer
        optionsPanel.SetActive(true);
        dimmer.SetActive(true);
    }

    public void CloseOptions()
    {
        // Disattiva pannello e dimmer
        optionsPanel.SetActive(false);
        dimmer.SetActive(false);
    }

    public void QuitGame()
    {
        // Chiude l'applicazione (funziona solo nel build)
        Application.Quit();
        Debug.Log("Gioco chiuso! (funziona solo nel build)");
    }
}
