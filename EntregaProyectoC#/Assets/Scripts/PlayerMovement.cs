using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 3;
    public float bonus = 1.5f;

    private bool activateBonus = false;
    private int timeBonus = 1;
    private Transform _transform;
    private Rigidbody _rb;

    void Awake()
    {
        _transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        if (movement.magnitude > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                activateBonus = true;
                StartCoroutine(BonusTime());
            }
            if (activateBonus == true)
            {
                movement = movement.normalized * (movementSpeed * bonus);
                _rb.velocity = new Vector3(movement.x, _rb.velocity.y, movement.z);
                _transform.forward = movement;
            }
            else
            {
                movement = movement.normalized * movementSpeed;
                _rb.velocity = new Vector3(movement.x, _rb.velocity.y, movement.z);
                _transform.forward = movement;
            }
        }
    }
    

    // Update is called once per frame
    private IEnumerator BonusTime()
    {
        while (true) {
            yield return new WaitForSeconds(timeBonus);
            activateBonus = false;
        }
    }
}
