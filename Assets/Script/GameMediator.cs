using UnityEngine;

public class GameMediator : MonoBehaviour, IGameMediator
{
    public void Notify(GameObject sender, string eventType)
    {
        if (eventType == "PlayerShoot")
        {
            Debug.Log("Player Hit");
        }

        if (eventType == "EnemyHit")
        {
            Debug.Log("Musuh terkena panah!");
        }
    }
}
