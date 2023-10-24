using System.Collections;
using UnityEngine;

public class FollowTheLeader : MonoBehaviour
{
    public Transform target;
    private Transform _transform;
    private Vector3 _movementDirection;
    
    public float sightRadius = 120;
    public float sightDistance = 25;
    public float speed = 1;
    private Rigidbody _rb;
    private float timeDuration = 1;

    private void Awake()
    {
        target = Player.instance.transform;
        _transform = GetComponent<Transform>();
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine(DangerTime());
    }

    void Update()
    {
        _movementDirection = (target.position - _transform.position).normalized*speed;
        if (
            Vector3.Distance(_transform.position, target.position) <= sightDistance &&
            Vector3.Angle(_transform.forward, _movementDirection) <= sightRadius / 2
        )
        {
          _rb.velocity=_movementDirection;
        }
            
     
    }
    
    private IEnumerator DangerTime()
    {
        while (true) {
            yield return new WaitForSeconds(timeDuration);
            speed+=0.05f;
        }
    }
}

