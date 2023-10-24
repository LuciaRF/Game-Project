
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GroundDetector : MonoBehaviour
{
    private List<Collider> _contactingColliders;
    public bool IsGrounded => _contactingColliders.Count >0;
    void Awake()
    {
        _contactingColliders = new List<Collider>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.isTrigger) {
            return;
        }
        _contactingColliders.Add(other);
    }

    private void OnTriggerExit(Collider other) {
        if (other.isTrigger) {
            return;
        }

        _contactingColliders.Remove(other);
    }
}
