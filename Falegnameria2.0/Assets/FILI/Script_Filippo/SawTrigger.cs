using UnityEngine;

public class SawTrigger : MonoBehaviour
{
    private MiniGameSegaManager manager;

    void Start()
    {
        manager = FindObjectOfType<MiniGameSegaManager>();
        if (manager == null)
            Debug.LogWarning("SawTrigger: MiniGameSegaManager non trovato nella scena.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (manager == null) return;
        if (!manager.GameStarted) return;
        if (manager.IsPaused) return;

        string tag = collision.tag;
        manager.OnSawTriggerEnter(tag, collision.gameObject);
    }
}
