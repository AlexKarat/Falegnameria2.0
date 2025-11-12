using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimento")]
    public float limitX = 8f; // Limite orizzontale del movimento (modifica se serve)

    [Header("Audio")]
    public AudioClip hitSound;    // Suono quando viene colpito da un legno
    public AudioClip healSound;   // Suono quando raccoglie un caschetto

    private AudioSource audioSource;

    void Start()
    {
        // Inizializza la sorgente audio
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Se il GameManager non esiste ancora oppure il gioco non è partito, non accettiamo input
        if (GameManager.Instance == null) return;
        if (!GameManager.Instance.GameStarted) return;
        if (GameManager.Instance.IsPaused) return;
        if (GameManager.Instance == null) return;

        // --> qui inserisci la logica esistente per muovere il player col mouse
        // esempio generico (sostituisci con il tuo codice di movimento):
        Vector3 mousePos = Input.mousePosition;
        // converti mousePos da schermo a world se usi world space:
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0f));
        // muovi solo in X (esempio semplice):
        transform.position = new Vector3(worldPos.x, transform.position.y, transform.position.z);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Quando il player collide con un oggetto che ha un tag specifico
        if (other.CompareTag("Wood"))
        {
            // Franco subisce danno
            GameManager.Instance.TakeDamage();

            // Riproduci suono di impatto
            if (hitSound != null)
                audioSource.PlayOneShot(hitSound);

            // Distruggi il pezzo di legno
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Helmet"))
        {
            // Franco guadagna una vita
            GameManager.Instance.GainLife();

            // Riproduci suono positivo
            if (healSound != null)
                audioSource.PlayOneShot(healSound);

            // Distruggi il caschetto raccolto
            Destroy(other.gameObject);
        }
    }
}
