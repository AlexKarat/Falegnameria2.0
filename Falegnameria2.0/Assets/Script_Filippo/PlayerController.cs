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
        // Se il gioco è in pausa o finito, non permettere movimenti
        if (GameManager.Instance == null || Time.timeScale == 0f)
            return;

        // Ottieni la posizione del mouse in coordinate mondo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Blocca il movimento solo sull'asse X (destra/sinistra)
        float clampedX = Mathf.Clamp(mousePosition.x, -limitX, limitX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
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
