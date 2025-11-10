using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0f;
            // mostra UI pausa se l'hai aggiunta
        }
        else
        {
            Time.timeScale = 1f;
            // nascondi UI pausa
        }
    }
}
