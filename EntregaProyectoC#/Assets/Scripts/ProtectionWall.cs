using UnityEngine;

public class ProtectionWall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == Layers.Bullet) 
            { PoolManager.instance.Despawn(other.gameObject);}
        }
}
