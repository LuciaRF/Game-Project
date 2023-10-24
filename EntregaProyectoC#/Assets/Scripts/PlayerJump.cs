using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpIntensity = 7;
    private Rigidbody _rb;
    private GroundDetector _groundDetector;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _groundDetector = GetComponentInChildren<GroundDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && _groundDetector.IsGrounded) {
            _rb.AddForce(Vector3.up * jumpIntensity, ForceMode.VelocityChange);
        }
    }
}
