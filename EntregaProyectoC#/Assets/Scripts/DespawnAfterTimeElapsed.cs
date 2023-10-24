
using UnityEngine;

public class DespawnAfterTimeElapsed : MonoBehaviour
{
    public float timeToWait = 6;

 

    void OnEnable() {
        Invoke(nameof(Despawn), timeToWait);
    }

 
    void Despawn()
    {
        PoolManager.instance.Despawn(gameObject);
    }
}
