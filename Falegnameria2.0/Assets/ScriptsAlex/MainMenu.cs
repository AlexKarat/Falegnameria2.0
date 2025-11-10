using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Nome della scena del gioco (da impostare in Inspector)
    public string gameSceneName;

    // Nome della scena delle opzioni
    public string optionsSceneName;

    // START GAME
    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    // APRI OPZIONI
    public void OpenOptions()
    {
        SceneManager.LoadScene(optionsSceneName);
    }

    // ESCI DAL GIOCO
    public void QuitGame()
    {
        Debug.Log("Gioco chiuso."); // utile in editor
        Application.Quit();
    }
}
