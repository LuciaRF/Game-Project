using DG.Tweening;
using UnityEngine;

public class DirectionPlayerBullet : MonoBehaviour
{
    
    private float speed = 5;
    private Transform _transform;
    private Rigidbody _rb;
    [SerializeField] private Material _mat;


    void Awake()
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        _mat = GetComponentInChildren<MeshRenderer>().material;
        
    }

    private void Start()
    {
        _transform.Rotate(0, -90, -90);
    }

    void Update()
    { 
        _rb.velocity = _transform.up * speed;
        _mat.DOColor(Color.green, .05f);
    }
    

}
