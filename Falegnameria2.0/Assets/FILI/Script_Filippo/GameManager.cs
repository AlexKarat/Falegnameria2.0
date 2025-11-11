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

    private bool isGameOver = false;
    private bool isPaused = false;

    void Awake()
    {
        // Singleton per accedere facilmente da altri script
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
        Time.timeScale = 1f; // assicurati che il gioco parta "attivo"
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    void Update()
    {
        if (!isPaused && !isGameOver)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                WinGame();
            }

            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    // ----------------------------
    // GESTIONE VITE
    // ----------------------------
    public void TakeDamage()
    {
        if (isGameOver || isPaused) return;

        currentLives--;
        UpdateLivesUI();

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    public void GainLife()
    {
        if (isGameOver || isPaused) return;

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
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    // ----------------------------
    // FINE GIOCO
    // ----------------------------
    // NUOVO METODO
    private void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("GAME OVER!");

        // --- MODIFICA AGGIUNTA ---
        // Salva il nome di QUESTA scena (es. "MiniGiocoLegna")
        // prima di caricare la scena di Game Over.
        StatoGioco.ScenaDaRiavviare = SceneManager.GetActiveScene().name;
        // --- FINE MODIFICA ---

        SceneManager.LoadScene("GameOver"); // metti il nome esatto della scena
    }

    private void WinGame()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        Debug.Log("WIN!");
        SceneManager.LoadScene("Win"); // metti il nome esatto della scena
    }
}
