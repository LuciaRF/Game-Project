using UnityEngine;

public class PlayerWeapon : Singleton<PlayerWeapon>
{
    public GameObject bulletPrefab;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        PoolManager.instance.Load(bulletPrefab, 25);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            PoolManager.instance.Spawn(bulletPrefab, _transform.position + Vector3.up, Quaternion.LookRotation(_transform.forward, Vector3.up));
        }
    }
}