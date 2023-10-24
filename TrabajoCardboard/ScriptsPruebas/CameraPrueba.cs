using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraPrueba : MonoBehaviour
{

//Tiempo que debe estar mirando el jugador
public float timeMovement = 2f;
//Distancia a la que llega el raycast
public float rayDistance = 100;

private LayerMask layerInteractable;
public Transform _jugador;
private float timeMovementPlayer = 0;
private float timeRespawn = 0;
private Vector3 positionPointOfInterest;

private Vector3 positionActualPlayer;

void Awake()
{
    StartCoroutine(TimeRespawn());
    Debug.Log("Enciende Corrutina");
    layerInteractable = LayerMask.GetMask("Interactable");
    positionActualPlayer = _jugador.position;
}

IEnumerator TimeRespawn()
{
    yield return new WaitForSeconds(120f);
    SceneManager.LoadScene("Menu");
}

IEnumerator TimeSelection()
{
    timeMovementPlayer += Time.deltaTime;
    Debug.Log(timeMovementPlayer);
    yield return timeMovementPlayer;
            
}

void Update()
{
   
    Debug.DrawRay(_jugador.position,_jugador.forward * rayDistance,Color.green);

    RaycastHit hit;

    if (Physics.Raycast(_jugador.position, _jugador.forward, out hit, rayDistance,layerInteractable))
    {
        positionPointOfInterest = hit.point;
        
        Debug.Log("Punto fijado");
        Debug.Log(positionPointOfInterest);

        
        positionActualPlayer.x = positionPointOfInterest.x;
        positionActualPlayer.z = positionPointOfInterest.z;
        

        StartCoroutine(TimeSelection());

        
        if (timeMovement <= timeMovementPlayer)
        {
            _jugador.position = positionActualPlayer;
            
            Debug.Log("Posicion tras pasar el tiempo componente positionActualPlayer");
            Debug.Log(positionActualPlayer);
            
            Debug.Log("Posicion tras pasar el tiempo jugador");
            Debug.Log(_jugador.position);

            timeMovementPlayer = 0.0f;

        }

    }
    else
    {
        //Debug.Log("Volvemos a empezar");
        timeMovementPlayer = 0.0f;
    }
}

}
