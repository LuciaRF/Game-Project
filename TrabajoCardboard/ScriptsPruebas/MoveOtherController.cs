using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveOtherController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _mouseSensitivity;

    private Vector2 _move;
    private Vector2 _mouse;

    public void OnMove(InputAction.CallbackContext context)
    {
        _move = context.ReadValue<Vector2>();
        
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        _mouse = context.ReadValue<Vector2>();
        
    }

    private void Update()
    {
        
        NewRotate();
        if(_move.sqrMagnitude <0.01) return;
        NewMove();
    }

    private void NewMove()
    {
        transform.Translate(new Vector3(0,0,_move.y)*(_moveSpeed*Time.deltaTime));
        transform.Rotate(Vector3.up*(_move.x* (_rotateSpeed * Time.deltaTime)));
        
    }
    private void NewRotate()
    {
        float yRotation = Mathf.Clamp(_mouse.y, -90, 90); // Limita el valor de rotación entre 90 y -90 grados
        yRotation = Mathf.Deg2Rad * -yRotation; // Convierte el valor de rotación a radianes
        float xRotation = Mathf.Clamp(_mouse.x, -90, 90); // Limita el valor de rotación entre 90 y -90 grados
        xRotation = Mathf.Deg2Rad * xRotation; // Convierte el valor de rotación a radianes

        Vector3 cameraPos = transform.position; // Guarda la posición actual de la cámara
        transform.RotateAround(cameraPos, new Vector3(1, 0, 0), yRotation * _mouseSensitivity); // Aplica la rotación en el eje y con la sensibilidad
        transform.RotateAround(cameraPos, new Vector3(0, 1, 0), xRotation * _mouseSensitivity); // Aplica la rotación en el eje x con la sensibilidad
        transform.position = cameraPos; // Establece la posición de la cámara de nuevo
       
    }
}
