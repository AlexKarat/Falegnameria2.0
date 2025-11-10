using UnityEngine;
using UnityEngine.UI; // Importa questo namespace per lavorare con la UI (es. Button)
using UnityEngine.SceneManagement; // Importa questo per gestire il caricamento delle scene

/// <summary>
/// Questo script gestisce la logica della schermata del menu principale.
/// Allegalo a un GameObject nella tua scena del menu (es. un GameObject vuoto chiamato "MenuManager" o al Canvas stesso).
/// </summary>
public class MenuManager : MonoBehaviour
{
    // --- Nomi delle Scene ---
    // Nell'Inspector di Unity, potrai inserire i nomi esatti delle scene dei tuoi minigiochi.
    // Questi nomi DEVONO corrispondere ai nomi dei file di scena che hai salvato
    // e che hai aggiunto alle "Build Settings".

    [Header("Nomi delle Scene dei Minigiochi")]
    [Tooltip("Il nome esatto della scena per il minigioco della sega circolare.")]
    public string nomeScenaSega = "ScenaSegaCircolare";

    [Tooltip("Il nome esatto della scena per il minigioco del caschetto di sicurezza.")]
    public string nomeScenaCaschetto = "ScenaCaschetto";

    [Tooltip("Il nome esatto della scena per il minigioco dei guanti e chiodi.")]
    public string nomeScenaGuanti = "ScenaGuanti";

    [Tooltip("Il nome esatto della scena per il quarto minigioco.")]
    public string nomeScenaMinigioco4 = "ScenaMinigioco4"; // Placeholder per il tuo quarto gioco


    // --- Metodi Pubblici per i Bottoni ---
    // Questi metodi devono essere "pubblici" (public)
    // in modo da poterli collegare all'evento OnClick() dei tuoi bottoni
    // direttamente dall'Inspector di Unity.

    /// <summary>
    /// Carica la scena del minigioco 1 (Sega Circolare).
    /// </summary>
    public void AvviaMinigiocoSega()
    {
        Debug.Log("Avvio minigioco: " + nomeScenaSega);
        // Carica la scena usando il nome fornito nell'Inspector
        SceneManager.LoadScene(nomeScenaSega);
    }

    /// <summary>
    /// Carica la scena del minigioco 2 (Caschetto).
    /// </summary>
    public void AvviaMinigiocoCaschetto()
    {
        Debug.Log("Avvio minigioco: " + nomeScenaCaschetto);
        SceneManager.LoadScene(nomeScenaCaschetto);
    }

    /// <summary>
    /// Carica la scena del minigioco 3 (Guanti e Chiodi).
    /// </summary>
    public void AvviaMinigiocoGuanti()
    {
        Debug.Log("Avvio minigioco: " + nomeScenaGuanti);
        SceneManager.LoadScene(nomeScenaGuanti);
    }

    /// <summary>
    /// Carica la scena del minigioco 4.
    /// </summary>
    public void AvviaMinigioco4()
    {
        Debug.Log("Avvio minigioco: " + nomeScenaMinigioco4);
        SceneManager.LoadScene(nomeScenaMinigioco4);
    }
}
