using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnSight : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform target;

    public float sightRadius = 120;
    public float sightDistance = 25;
    public float shootFreq = 1;
    public int bulletDamage = 1;

    private Transform _transform;

    private void Awake() {
        _transform = transform;
        target = Player.instance.transform;
    }

    private void Start() {
        StartCoroutine(ShootCoroutine());
    }

    // Update is called once per frame
    IEnumerator ShootCoroutine()
    {
        while (true) {
            if (target == null) {
                break;
            }

            var targetDirection = target.position - _transform.position;
            if (
                Vector3.Distance(_transform.position, target.position) <= sightDistance &&
                Vector3.Angle(_transform.forward, targetDirection) <= sightRadius / 2
                ) { 
                var bullet = PoolManager.instance.Spawn(bulletPrefab, _transform.position + Vector3.up, Quaternion.LookRotation(targetDirection, Vector3.up)).GetComponent<DamageOnTriggerEnter>();
                bullet.damage = bulletDamage;
                yield return new WaitForSeconds(shootFreq);
            } else {
                yield return null;
            }
        }
    }
}
