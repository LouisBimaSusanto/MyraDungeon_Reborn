using UnityEngine;

public interface IWaveObserver
{
    void OnEnemyKilled(int totalKilled, int totalRequired);
    void OnWaveComplete(int waveNumber);
}
