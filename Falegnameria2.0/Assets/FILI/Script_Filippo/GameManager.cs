using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game Settings")]
    public int maxLives = 3;
    private int currentLives;
    public float timer = 180f; // 3 minuti

    [Header("UI Elements")]
    public TextMeshProUGUI timerText;
    public GameObject[] lifeIcons; // i 3 caschetti gialli in alto a sinistra
    public GameObject pausePanel;  // pannello di pausa
    public GameObject startButton; // 🔹 pulsante Start da mostrare all'avvio

    private bool isGameOver = false;
    private bool isPaused = false;
    private bool gameStarted = false;

    // Proprietà pubbliche in sola lettura
    public bool IsPaused => isPaused;
    public bool GameStarted => gameStarted;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentLives = maxLives;
        UpdateLivesUI();

        // 🔹 Il gioco parte fermo finché non si preme "Start"
        gameStarted = false;
        Time.timeScale = 0f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        if (startButton != null)
            startButton.SetActive(true);
    }

    void Update()
    {
        // -------------------------
        // PAUSA (ESC)
        // -------------------------
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 🔹 Permetti la pausa solo se il gioco è iniziato e non è finito
            if (gameStarted && !isGameOver)
                TogglePause();
        }

        // Se il gioco non è partito o è in pausa o è finito, non aggiornare timer
        if (!gameStarted || isPaused || isGameOver)
            return;

        // -------------------------
        // TIMER
        // -------------------------
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            WinGame();
        }

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        if (timerText != null)
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // ----------------------------
    // START GAME
    // ----------------------------
    public void StartGame()
    {
        gameStarted = true;
        isPaused = false;
        isGameOver = false;
        Time.timeScale = 1f;

        Debug.Log("Gioco iniziato!");

        if (startButton != null)
            startButton.SetActive(false);
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    // ----------------------------
    // GESTIONE VITE
    // ----------------------------
    public void TakeDamage()
    {
        if (isGameOver || isPaused || !gameStarted) return;

        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    public void GainLife()
    {
        if (isGameOver || isPaused || !gameStarted) return;

        if (currentLives < maxLives)
        {
            currentLives++;
            UpdateLivesUI();
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].SetActive(i < currentLives);
        }
    }

    // ----------------------------
    // PAUSA
    // ----------------------------
    public void TogglePause()
    {
        if (!gameStarted || isGameOver) return;

        if (isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;

        if (pausePanel != null)
            pausePanel.SetActive(true);

        Debug.Log("Gioco in pausa");
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        if (pausePanel != null)
            pausePanel.SetActive(false);

        Debug.Log("Gioco ripreso");
    }

    // ----------------------------
    // FINE GIOCO
    // ----------------------------
    private void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("GAME OVER!");

        StatoGioco.ScenaDaRiavviare = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene("GameOver");
    }

    private void WinGame()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("WIN!");

        SceneManager.LoadScene("Win");
    }
}
