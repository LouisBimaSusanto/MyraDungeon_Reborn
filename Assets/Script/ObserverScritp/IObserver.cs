using UnityEngine;

public interface IObserver
{
    void OnNotify(string eventType);
}
