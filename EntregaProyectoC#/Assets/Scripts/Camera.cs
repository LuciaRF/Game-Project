using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    private Vector3 offset = new Vector3(0,5,-10);
    private Transform _transform;
    
    void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    
    void Update()
    {
        if (target == null)
        {
            return;
        }

        transform.position = target.position + offset;
        transform.LookAt(target,Vector3.up);
    }
}
