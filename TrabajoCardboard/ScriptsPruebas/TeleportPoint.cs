using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPoint : MonoBehaviour
{

    public Transform jugador;
    
    public void OnPointerEnter()
    {
        Vector3 newPos = new Vector3(transform.localPosition.x, transform.localPosition.y,
            transform.localPosition.z);
        Debug.Log(newPos);
        jugador.localPosition = newPos;
      
    }
}