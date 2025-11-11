using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MiniGameSegaManager : MonoBehaviour
{
    [Header("Nomi scene (setta nel Inspector)")]
    public string winSceneName = "Win";
    public string gameOverSceneName = "GameOver";

    [Header("Bracci Tronco (in ordine)")]
    public GameObject[] bracciTronco; // BraccioTronco1, BraccioTronco2, BraccioTronco3, BraccioTronco4
    private int currentIndex = 0;

    [Header("Timer")]
    public float totalTime = 60f; // 1 minuto totale per tutti
    private float remainingTime;
    private bool gameEnded = false;

    [Header("UI")]
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI progressText;

    void Start()
    {
        remainingTime = totalTime;
        AttivaSoloTronco(0);
        AggiornaUI();
    }

    void Update()
    {
        if (gameEnded) return;

        // Timer countdown
        remainingTime -= Time.deltaTime;
        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            GameOver();
        }

        AggiornaTimer();
    }

    // Riceve evento dal collider Sega (SawTrigger)
    public void OnSawTriggerEnter(string otherTag, GameObject colpito)
    {
        if (gameEnded) return;

        if (otherTag == "Hand")
        {
            Debug.Log("PERSO: Sega su Hand");
            GameOver();
        }
        else if (otherTag == "CutPoint")
        {
            // Verifica che il CutPoint appartenga al tronco corrente
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
        }
        else
        {
            Debug.Log("Saw collided with tag: " + otherTag);
        }
    }

    // Attiva solo il tronco corrente
    void AttivaSoloTronco(int index)
    {
        for (int i = 0; i < bracciTronco.Length; i++)
        {
            bracciTronco[i].SetActive(i == index);
        }
    }

    // Aggiorna UI
    void AggiornaUI()
    {
        if (progressText != null)
            progressText.text = $"{currentIndex + 1} / {bracciTronco.Length}";

        AggiornaTimer();
    }

    void AggiornaTimer()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(remainingTime / 60f);
            int seconds = Mathf.FloorToInt(remainingTime % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    void Win()
    {
        gameEnded = true;
        SceneManager.LoadScene(winSceneName);
    }

    void GameOver()
    {
        gameEnded = true;

        // --- MODIFICA AGGIUNTA ---
        // Salva il nome di QUESTA scena (es. "MiniGiocoSegaCircolare")
        // prima di caricare la scena di Game Over.
        StatoGioco.ScenaDaRiavviare = SceneManager.GetActiveScene().name;
        // --- FINE MODIFICA ---

        SceneManager.LoadScene(gameOverSceneName);
    }
}
