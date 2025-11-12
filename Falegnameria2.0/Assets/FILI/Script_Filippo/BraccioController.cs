using UnityEngine;

// [RequireComponent(typeof(BraccioController))] // ERRORE RIMOSSO
public class BraccioController : MonoBehaviour
{
    [Header("Limiti orizzontali")]
    public float leftX = -4.5f;
    public float rightX = 4.5f;

    [Header("Velocità")]
    public float speed = 3f;

    [HideInInspector]
    public bool isActiveTrunk = false; // impostato dal manager

    private bool movingRight = true;
    private MiniGameSegaManager manager; // Variabile per salvare il manager

    void Start()
    {
        // CORREZIONE: Cerca il manager UNA SOLA VOLTA all'inizio
        manager = GameObject.FindObjectOfType<MiniGameSegaManager>();
        if (manager == null)
        {
            Debug.LogError("BraccioController: MiniGameSegaManager non trovato!");
        }
    }

    void Update()
    {
        // Protezione: non muovere se non è il tronco attivo
        if (!isActiveTrunk) return;

        // CORREZIONE: usa la variabile 'manager' salvata (molto più veloce)
        if (manager == null)
        {
            // Se non trovi manager, non eseguire movimento
            return;
        }
        else
        {
            // Protezione dal manager: aspettare Start e non muovere in pausa
            if (!manager.GameStarted) return;
            if (manager.IsPaused) return;
        }

        // Movimento solo mentre il tasto sinistro è premuto
        if (!Input.GetMouseButton(0)) return;

        float step = speed * Time.deltaTime;
        Vector3 pos = transform.position;

        if (movingRight)
        {
            pos.x += step;
            if (pos.x >= rightX) movingRight = false;
        }
        else
        {
            pos.x -= step;
            if (pos.x <= leftX) movingRight = true;
        }

        transform.position = pos;
    }
}