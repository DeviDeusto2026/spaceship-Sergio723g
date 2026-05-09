using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossPrefab;
    public float spawnRate = 5f;
    public float bossSpawnTime = 30f;
    private float nextSpawn = 0f;
    private bool bossSpawned = false;

    void Update()
    {
        if (!bossSpawned && Time.time > bossSpawnTime)
        {
            bossSpawned = true;
            Vector3 spawnPos = new Vector3(20f, 0f, 0f);
            Instantiate(bossPrefab, spawnPos, Quaternion.identity);
            return;
        }

        if (!bossSpawned && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Vector3 spawnPos = new Vector3(
                Random.Range(-10f, 10f),
                Random.Range(-5f, 5f),
                Random.Range(-10f, 10f));
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}