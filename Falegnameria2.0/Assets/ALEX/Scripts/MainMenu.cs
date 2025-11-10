using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene Names")]
    public string gameSceneName;      // nome della scena principale di gioco
    public string optionsSceneName;   // nome della scena delle opzioni

    // START GAME
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    // APRI SCENA OPZIONI
    public void OpenOptions()
    {
        SceneManager.LoadScene(optionsSceneName);
    }

    // ESCI DAL GIOCO
    public void QuitGame()
    {
        Debug.Log("Quit Game"); // visibile in editor
        Application.Quit();     // funziona solo in build
    }
}
