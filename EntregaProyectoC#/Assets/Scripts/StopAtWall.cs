using UnityEngine;

public class StopAtWall : MonoBehaviour
{
    private Transform _transform;
    private Vector3 _position;
    private float _rayDistance = 5f ;
    public LayerMask layer;
    private Vector3 direction;

    void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    
    void Update()
    {
        _position = new Vector3(_transform.position.x, 0.5f, _transform.position.z);
        // Crea un rayo desde el firePoint hacia la dirección en la que apunta
        direction = _transform.TransformDirection(Vector3.forward) * _rayDistance;
        Ray ray = new Ray(_position, direction);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayDistance))
        {
            if (Physics.Raycast(ray, out hit, _rayDistance,layer))
            { 
                _transform.GetComponent<FollowTheLeader>().enabled = false;
            }
            _transform.GetComponent<FollowTheLeader>().enabled = true;
        }
        
    }
    
}
