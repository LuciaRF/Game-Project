using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteractor : MonoBehaviour
{
    
//Tiempo que debe estar mirando el jugador
    public float timeMovement = 2f;
//Distancia a la que llega el raycast
    public float rayDistance = 15;

    private LayerMask layerStart;
    private LayerMask layerExit;
    private Transform _jugador;
    private float timeMovementPlayer =0;


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    void Start()
    {
        layerStart = LayerMask.GetMask("Start");
        layerExit = LayerMask.GetMask("Exit");
        _jugador = transform.Find("Camera");
    }

    IEnumerator TimeSelection()
    {
        timeMovementPlayer += Time.deltaTime;
        yield return timeMovementPlayer;
            
    }
    

    void Update()
    {
        Debug.DrawRay(_jugador.position,_jugador.forward * rayDistance,Color.green);

        RaycastHit hit;

        if (Physics.Raycast(_jugador.position, _jugador.forward, out hit, rayDistance,layerStart))
        {

            StartCoroutine(TimeSelection());
            
            if (timeMovement <= timeMovementPlayer)
            {
                timeMovementPlayer = 0.0f;
                PlayGame();

            }

        }
        else if (Physics.Raycast(_jugador.position, _jugador.forward, out hit, rayDistance,layerExit))
        {
            
            StartCoroutine(TimeSelection());

            if (timeMovement <= timeMovementPlayer)
            {
                timeMovementPlayer = 0.0f;
                QuitGame();

            }

        }
        else
        {
            Debug.Log("No estamos marcando nada");
            timeMovementPlayer = 0.0f;
        }
        
    }

}