using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Profiling.Experimental;

public class ObjectInteractableCanvas : MonoBehaviour
{


    public Transform camera;

    private Transform objectInteractable;
    private bool isLooking = false;
    private LayerMask layerCandle;
    
    private LayerMask layerInteractable;
    private float rayDistance = 100;
    private LayerMask layeractivateObject;
    public GameObject TextDetect;
    public Transform texto;    
    private TextMeshProUGUI textMeshPro;
    
    private string objectName;

    void Awake()
    {
        TextDetect.SetActive(false);
        layerInteractable = LayerMask.GetMask("Interactable");
        layeractivateObject = LayerMask.GetMask("ActivateObject");
        objectInteractable = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        
        {
            RaycastHit hit;

            
            
            if (Physics.Raycast(camera.position, camera.forward, out hit,rayDistance, layerInteractable))
            {
                Debug.Log(hit.collider.name);
                if (hit.transform == transform)
                {
                    isLooking = true;
                }
                else
                {
                    isLooking = false;
                    //TextDetect.SetActive(false);
                }


                if (isLooking)
                {
                    objectName = hit.transform.name;
                    
                    textMeshPro = texto.GetComponent<TextMeshProUGUI>();
                    
                    textMeshPro.text = objectName;
                    TextDetect.SetActive(true);

                }
                
            } else if (Physics.Raycast(camera.position, camera.forward, out hit,rayDistance, layeractivateObject))
                
            {
                Debug.Log("Esto es un candle");
                if (hit.transform == transform)
                {
                    isLooking = true;
                }
                else
                {
                    isLooking = false;
                   // TextDetect.SetActive(false);
                }

                if (isLooking)
                {
                    textMeshPro = texto.GetComponent<TextMeshProUGUI>();
                    textMeshPro.text = "Espera y verás";
                    TextDetect.SetActive(true);
                }
                
            }
            else
            {
                TextDetect.SetActive(false);
            }
            
        }
    }
}
