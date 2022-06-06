using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TeleportAI : MonoBehaviour
{
    public GameObject currentTeleporter;
    [SerializeField] private NavMeshAgent navAgent;

    public void Update()
    {
        if (currentTeleporter != null)
        {
            Debug.Log(currentTeleporter);
            navAgent.Warp(currentTeleporter.GetComponent<Teleporter>().GetDestination().position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleporter"))
        {
            currentTeleporter = other.gameObject;
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
