using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoint;
    public int[] enemiesPerWave;
    public float spawnInternal = 1f;

    private int currentWave = 0;
    private int enemiesSpawnerd = 0;
    private int enemiesKilled = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WaveMediator.instance.SetWaveManager(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
