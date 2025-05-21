using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public int[] enemiesPerWave;
    public float spawnInternal = 1f;

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
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
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
