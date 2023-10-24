using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class CanvasDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TextDetect;
    public Transform texto;    
    private LayerMask layerInteractable;
    private float rayDistance = 100;
    private LayerMask layeractivateObject;

    private string objectName;
    private TextMeshProUGUI textMeshPro;
    
    void Start()
    {
        TextDetect.SetActive(false);
        layerInteractable = LayerMask.GetMask("Interactable");
        layeractivateObject = LayerMask.GetMask("ActivateObject");
    }


    void Update()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, transform.forward, out hit,rayDistance,layerInteractable))
        {
            objectName = hit.transform.name;
            
            textMeshPro = texto.GetComponent<TextMeshProUGUI>();
            textMeshPro.text = objectName;
            TextDetect.SetActive(true);


        }
        else  if(Physics.Raycast(transform.position, transform.forward, out hit,rayDistance,layeractivateObject))
        {
            textMeshPro = texto.GetComponent<TextMeshProUGUI>();
            textMeshPro.text = "Espera y verás";
            TextDetect.SetActive(true);
        }
        else
        {
            TextDetect.SetActive(false);
        }
        
        
    }
}
