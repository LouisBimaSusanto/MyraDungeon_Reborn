using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnDestroy()
    {
        if (WaveMediator.Instance != null)
        {
            WaveMediator.Instance.EnemyDie();
        }
    }
}
