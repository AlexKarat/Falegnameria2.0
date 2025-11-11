using UnityEngine;

public class SawTrigger : MonoBehaviour
{
    private MiniGameSegaManager manager;

    void Start()
    {
        manager = FindObjectOfType<MiniGameSegaManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (manager == null) return;
        manager.OnSawTriggerEnter(collision.tag, collision.gameObject);
    }
}
