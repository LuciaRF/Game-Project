using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraInteraction : MonoBehaviour
{

//Tiempo que debe estar mirando el jugador
public float timeMovement = 2f;
//Distancia a la que llega el raycast
public float rayDistance = 100;

private LayerMask layerInteractable;
private Transform _jugador;
private float timeMovementPlayer = 0;
private float timeRespawn = 0;
private Vector3 positionPointOfInterest;

private Vector3 positionActualPlayer;
private GameObject _gazedAtObject = null;

public AudioSource myAudioSource;

void Start()
{
    StartCoroutine(TimeRespawn());
    Debug.Log("Enciende Corrutina");
    layerInteractable = LayerMask.GetMask("Interactable");
    _jugador = transform.Find("Camera");
    positionActualPlayer = _jugador.position;
    myAudioSource = GetComponent<AudioSource>();
    myAudioSource.Play();
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

        positionActualPlayer =
            new Vector3(positionPointOfInterest.x, positionActualPlayer.y, positionPointOfInterest.z);


        StartCoroutine(TimeSelection());

        
        if (timeMovement <= timeMovementPlayer)
        {
            transform.position = positionActualPlayer;
            timeMovementPlayer = 0.0f;
        }
    }
    else
    {
        timeMovementPlayer = 0.0f;
    }
}

}
