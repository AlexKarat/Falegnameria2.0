using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject woodPrefab;
    public GameObject helmetPrefab;

    [Header("Spawn area")]
    public float spawnXMin = -8f;
    public float spawnXMax = 8f;
    public float spawnY = 6f;

    [Header("Rates")]
    public float woodSpawnInterval = 0.6f;    // ogni quanto spawnare il legno
    public float helmetSpawnIntervalMin = 4f; // casco meno frequente: random tra min e max
    public float helmetSpawnIntervalMax = 8f;

    private Coroutine woodRoutine;
    private Coroutine helmetRoutine;

    private void OnEnable()
    {
        woodRoutine = StartCoroutine(WoodSpawner());
        helmetRoutine = StartCoroutine(HelmetSpawner());
    }

    private void OnDisable()
    {
        if (woodRoutine != null) StopCoroutine(woodRoutine);
        if (helmetRoutine != null) StopCoroutine(helmetRoutine);
    }

    IEnumerator WoodSpawner()
    {
        while (true)
        {
            Spawn(woodPrefab);
            yield return new WaitForSeconds(woodSpawnInterval);
        }
    }

    IEnumerator HelmetSpawner()
    {
        while (true)
        {
            float wait = Random.Range(helmetSpawnIntervalMin, helmetSpawnIntervalMax);
            yield return new WaitForSeconds(wait);
            Spawn(helmetPrefab);
        }
    }

    void Spawn(GameObject prefab)
    {
        float x = Random.Range(spawnXMin, spawnXMax);
        Vector3 pos = new Vector3(x, spawnY, 0);
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
