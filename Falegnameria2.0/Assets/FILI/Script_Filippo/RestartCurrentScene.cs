using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCurrentScene : MonoBehaviour
{
    [Header("Scena di Fallback")]
    [Tooltip("Nome della scena da caricare se 'ScenaDaRiavviare' non è impostata (es. MainMenu)")]
    public string fallbackSceneName = "MainMenu"; // Modifica "MainMenu" con il nome della tua scena principale

    public void Restart()
    {
        // 1. Rimetti il tempo normale (se era in pausa)
        Time.timeScale = 1f;

        // 2. NON distruggere il GameManager da qui.
        // Se il GameManager è un singleton (come il tuo in MiniGiocoLegna),
        // è progettato per gestire se stesso. Distruggerlo
        // manualmente può causare errori. La scena del minigioco
        // che ricarichiamo si occuperà di gestirlo.

        // 3. Carica la scena corretta
        if (!string.IsNullOrEmpty(StatoGioco.ScenaDaRiavviare))
        {
            // Ricarica la scena del minigioco che avevamo salvato!
            // (es. "MiniGiocoLegna" o "MiniGiocoSegaCircolare")
            SceneManager.LoadScene(StatoGioco.ScenaDaRiavviare);
        }
        else
        {
            // 4. Fallback di sicurezza
            // Se per qualche motivo la variabile è vuota (magari hai
            // avviato il gioco direttamente dalla scena GameOver),
            // torna al menu principale per evitare un errore.
            Debug.LogWarning("StatoGioco.ScenaDaRiavviare non era impostata! Ritorno al menu: " + fallbackSceneName);
            SceneManager.LoadScene(fallbackSceneName);
        }
    }
}