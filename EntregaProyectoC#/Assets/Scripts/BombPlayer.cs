
using UnityEngine;

public class BombPlayer : Singleton<BombPlayer>
{
    public GameObject bombPrefab;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Start()
    {
        PoolManager.instance.Load(bombPrefab, 5);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            PoolManager.instance.Spawn(bombPrefab, _transform.position, Quaternion.LookRotation(_transform.forward, Vector3.up));
        }
    }
}
