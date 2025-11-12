using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MiniGameSegaManager : MonoBehaviour
{
    [Header("Nomi scene (setta nel Inspector)")]
    public string winSceneName = "Win";
    public string gameOverSceneName = "GameOver";

    [Header("UI / Pause / Start")]
    public GameObject pausePanel;       // assegna il PausePanel nel Canvas
    public GameObject startButton;      // assegna il StartButton nel Canvas
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI progressText;

    [Header("Bracci Tronco (in ordine)")]
    public GameObject[] bracciTronco;   // BraccioTronco1..4 (in ordine)

    [Header("Timer")]
    public float totalTime = 60f;       // tempo totale per completare 4 tronchi

    // stato gioco
    private int currentIndex = 0;
    private float remainingTime;
    private bool gameEnded = false;
    private bool isPaused = false;
    private bool gameStarted = false;

    // proprietà leggibili dagli altri script
    public bool IsPaused => isPaused;
    public bool GameStarted => gameStarted;

    void Start()
    {
        remainingTime = totalTime;
        currentIndex = 0;
        AttivaSoloTronco(currentIndex);
        AggiornaUI();

        // Inizio con pannello pausa spento e StartButton visibile,
        // e gioco fermo (timeScale 0) fino allo Start
        if (pausePanel != null) pausePanel.SetActive(false);
        if (startButton != null) startButton.SetActive(true);

        gameStarted = false;
        isPaused = false;
        gameEnded = false;

        Time.timeScale = 0f; // blocca il gioco finché non premi Start
    }

    void Update()
    {
        // ESC apre/chiude pausa solo se il gioco è iniziato e non finito
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameStarted && !gameEnded)
                TogglePause();
        }

        // se il gioco non è iniziato, in pausa o finito, non aggiornare timer né logica
        if (!gameStarted || isPaused || gameEnded) return;

        // timer
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            GameOver();
            return;
        }

        AggiornaTimer();
    }

    // Metodo pubblico per il bottone Start
    public void StartGame()
    {
        if (gameStarted) return;

        gameStarted = true;
        isPaused = false;
        Time.timeScale = 1f;

        if (startButton != null) startButton.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);

        Debug.Log("MiniGiocoSegaCircolare: game started");
    }

    // Metodo chiamato da SawTrigger
    public void OnSawTriggerEnter(string otherTag, GameObject colpito)
    {
        if (!gameStarted || isPaused || gameEnded) return; // ignoriamo eventi prima dello start o in pausa

        if (otherTag == "Hand")
        {
            Debug.Log("PERSO: Sega su Hand");
            GameOver();
        }
        else if (otherTag == "CutPoint")
        {
            // Verifica appartenenza al tronco corrente
            GameObject troncoCorrente = bracciTronco[currentIndex];
            if (colpito.transform.IsChildOf(troncoCorrente.transform))
            {
                troncoCorrente.SetActive(false);
                currentIndex++;

                if (currentIndex >= bracciTronco.Length)
                {
                    Debug.Log("VINTO: Tutti i tronchi tagliati!");
                    Win();
                }
                else
                {
                    AttivaSoloTronco(currentIndex);
                    AggiornaUI();
                }
            }
            else
            {
                Debug.Log("CutPoint toccato ma non del tronco attivo");
            }
        }
        else
        {
            Debug.Log("Saw collided with tag: " + otherTag);
        }
    }

    // Abilita solo il tronco indicato dall'indice, disattiva gli altri
    void AttivaSoloTronco(int index)
    {
        for (int i = 0; i < bracciTronco.Length; i++)
        {
            GameObject tronco = bracciTronco[i];
            bool isActive = (i == index);

            // 1. Attiva/Disattiva il GameObject
            tronco.SetActive(isActive);

            // 2. CORREZIONE LOGICA: 
            // Dobbiamo dire allo script 'BraccioController' se è attivo o no
            BraccioController controller = tronco.GetComponent<BraccioController>();
            if (controller != null)
            {
                controller.isActiveTrunk = isActive;
            }
            else
            {
                // Utile per debug se ti dimentichi di aggiungere lo script
                if (isActive)
                    Debug.LogWarning($"Il tronco {tronco.name} è stato attivato ma non ha un BraccioController!");
            }
        }
        AggiornaUI();
    }

    void AggiornaUI()
    {
        if (progressText != null)
            progressText.text = $"{Mathf.Clamp(currentIndex + 1, 1, bracciTronco.Length)} / {bracciTronco.Length}";
        AggiornaTimer();
    }

    void AggiornaTimer()
    {
        if (timerText == null) return;
        int minutes = Mathf.FloorToInt(remainingTime / 60f);
        int seconds = Mathf.FloorToInt(remainingTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void Win()
    {
        gameEnded = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(winSceneName);
    }

    void GameOver()
    {
        gameEnded = true;
        Time.timeScale = 1f;
        // StatoGioco.ScenaDaRiavviare = SceneManager.GetActiveScene().name; // Ho lasciato questa riga com'era
        SceneManager.LoadScene(gameOverSceneName);
    }

    // PAUSA
    public void TogglePause()
    {
        if (gameEnded || !gameStarted) return;

        if (isPaused) ResumeGame();
        else PauseGame();
    }

    public void PauseGame()
    {
        if (gameEnded) return;
        isPaused = true;
        Time.timeScale = 0f;
        if (pausePanel != null) pausePanel.SetActive(true);
        Debug.Log("MiniGameSegaCircolare: Pausa ON");
    }

    public void ResumeGame()
    {
        if (gameEnded) return;
        isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null) pausePanel.SetActive(false);
        Debug.Log("MiniGameSegaCircolare: Pausa OFF");
    }
}