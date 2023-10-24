using UnityEngine;

public class LookAtTheLeader : MonoBehaviour
{
    private Transform _transform;

    public Transform player;

    private Vector3 _movementDirection;
    public float speed = 2; // Velocidad de movimiento
    public float rotationSpeed = 10f;
    void Awake()
    {
        _transform = GetComponent<Transform>();
        player = Player.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _movementDirection = (player.position - _transform.position).normalized*speed;
        Quaternion lookRotation = Quaternion.LookRotation(_movementDirection, Vector3.up);
        _transform.rotation = Quaternion.Slerp(_transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        
    }
    
}
