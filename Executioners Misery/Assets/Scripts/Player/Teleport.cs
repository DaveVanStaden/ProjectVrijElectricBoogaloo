using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private TransitionAudio transitionAudio;
    private GameObject currentTeleporter;

    public void Update()
    {
        if (currentTeleporter != null)
        {
            transitionAudio.FadeAudio();
            gameObject.transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleporter"))
        {
            currentTeleporter = other.gameObject;
            transitionAudio = other.GetComponent<TransitionAudio>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Teleporter"))
        {
            if (other.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
