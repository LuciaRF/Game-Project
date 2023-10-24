using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCandles : MonoBehaviour
{

    public Transform camera;
    
    private Transform candle;
    private bool isLooking = false;
    private float timeLooking = 0f;
    private LayerMask layerCandle;
    
    public float timeToActivate = 2f;

    void Awake()
    {
        layerCandle = LayerMask.GetMask("ActivateObject");
        candle = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.position, camera.forward, out hit,layerCandle))
            {
                if (hit.transform == transform)
                {
                    isLooking = true;
                }
                else
                {
                    isLooking = false;
                    timeLooking = 0f;
                }
            }

            if (isLooking)
            {
                timeLooking += Time.deltaTime;
                if (timeLooking >= timeToActivate)
                {
                    candle.GetComponent<Animator>().enabled = false;
                    candle.GetComponent<Rigidbody>().useGravity = true;
                }
            }
        }
    }
}
