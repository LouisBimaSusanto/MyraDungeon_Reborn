using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<IObserver> observers = new List<IObserver>();

    private void Awake()
    {
        instance = this;
    }

    public void Register(IObserver observer)
    {
        observers.Add(observer);
    }

    public void NotifyAll(string eventType)
    {
        foreach (var observer in observers)
        {
            observer.OnNotify(eventType);
        }
    }
}
