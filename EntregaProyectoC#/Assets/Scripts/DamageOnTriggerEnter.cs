using UnityEngine;

public class DamageOnTriggerEnter : MonoBehaviour
{
    public bool destroySelf;
    public LayerMask targetLayer;
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (targetLayer == (1 << other.gameObject.layer | targetLayer)) {
            var health = other.GetComponent<Health>();
            if (health)
            {
                health.TakeDamage(damage);
            }

            if (destroySelf) {
                PoolManager.instance.Despawn(gameObject);
            }
        }
    }
}
