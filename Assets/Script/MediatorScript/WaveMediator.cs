using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveMediator : MonoBehaviour
{
    public static WaveMediator Instance;

    private List<IWaveObserver> observers = new();
    public WaveManager waveManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterObserver(IWaveObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void UnregisterObserver(IWaveObserver observer) 
    {
        if (observers.Contains(observer)) 
        {
            observers.Remove(observer);
        }
    }

    public void NotifyEnemyKilled(int killed, int required)
    {
        foreach (var observer in observers)
        {
            observer.OnEnemyKilled(killed, required);
        }
    }

    public void NotifyOnCompleted(int wave)
    {
        foreach (var observer in observers)
        {
            observer.OnWaveComplete(wave);
        }
    }

    public void EnemyDie()
    {
        if (waveManager != null)
        {
            waveManager.ReportEnemyKilled();
        }
    }

    public void SetWaveManager(WaveManager manager)
    {
        waveManager = manager;
    }
}
