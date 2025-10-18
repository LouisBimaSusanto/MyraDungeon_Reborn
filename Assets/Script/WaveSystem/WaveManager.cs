using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("enemy prefab")]
    public GameObject enemyPrefab_A;
    public GameObject enemyPrefab_B;

    [Header("Spawn Setting")]
    public Transform[] spawnPoints;
    public int[] enemiesPerWave;
    public float spawnInternal = 1f;

    [Header("Probability Spawn")]
    [Range(0f, 1f)] public float enemyAChange = 0.7f;
    [Range(0f, 1f)] public float enemyBChange = 0.3f;

    [Header("Ennmy Value Setting's")]
    private int currentWave = 0;
    private int enemiesSpawned = 0;
    private int enemiesKilled = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaveMediator.Instance.SetWaveManager(this);
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        enemiesSpawned = 0;
        enemiesKilled = 0;

        while (enemiesSpawned < enemiesPerWave[currentWave])
        {
            SpawnEnemy();
            enemiesSpawned++;
            yield return new WaitForSeconds(spawnInternal);
        }
    }

    void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        float rand = Random.value; //This change value between 0-1
        GameObject prefabToSpawn = (rand <= enemyAChange) ? enemyPrefab_A : enemyPrefab_B;

        Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
    }

    public void ReportEnemyKilled()
    {
        enemiesKilled++;
        WaveMediator.Instance.NotifyEnemyKilled(enemiesKilled, enemiesPerWave[currentWave]);

        if (enemiesKilled >= enemiesPerWave[currentWave])
        {
            WaveMediator.Instance.NotifyOnCompleted(currentWave);
            currentWave++;

            if (currentWave < enemiesPerWave.Length)
            {
                StartCoroutine(SpawnWave());
            }
            else
            {
                Debug.Log("All Waves Complete!");   
            }
        }
    }
}
