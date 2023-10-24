using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSnitch : MonoBehaviour
{
    private bool isLooking = false;
    private float timeLooking = 0f;
    public float timeToActivate = 2f;
    public Transform target;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform == target)
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
                target.GetComponent<Animator>().SetTrigger("Start");
            }
        }
    }
}
