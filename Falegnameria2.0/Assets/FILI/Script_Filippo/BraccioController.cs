using UnityEngine;

[RequireComponent(typeof(BraccioController))]
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
    private bool isMoving = false; // 🔹 NUOVO: controlla se il tronco è in movimento o fermo

    void Update()
    {
        // se non è il tronco attivo → non fare nulla
        if (!isActiveTrunk) return;

        // controlla stato del gioco
        var manager = FindObjectOfType<MiniGameSegaManager>();
        if (manager == null) return;
        if (!manager.GameStarted || manager.IsPaused) return;

        // 🔹 Controllo clic per attivare/disattivare il movimento
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = !isMoving; // inverte stato
        }

        // se non in movimento → stop
        if (!isMoving) return;

        // 🔹 Movimento automatico destra-sinistra
        float step = speed * Time.deltaTime;
        Vector3 pos = transform.position;

        if (movingRight)
        {
            pos.x += step;
            if (pos.x >= rightX)
                movingRight = false;
        }
        else
        {
            pos.x -= step;
            if (pos.x <= leftX)
                movingRight = true;
        }

        transform.position = pos;
    }
}
