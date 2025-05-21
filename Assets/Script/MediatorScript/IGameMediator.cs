using UnityEngine;

public interface IGameMediator
{
    void Notify(GameObject sender, string eventType);
}
