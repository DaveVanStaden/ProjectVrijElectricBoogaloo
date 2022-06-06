using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class AIExecution : MonoBehaviour
{
    public Transform target;
    public Transform teleportExecution;
    public Transform teleportCity;
    public Transform executionSite;
    public Transform Guilotine;
    public Transform basePosition;
    private NavMeshAgent agent;
    
    public bool sendToExecution;
    public bool sendToCage;
    public bool sendToTeleporterExecution;
    public bool sendToTeleporterCity;
    public bool canSendToTeleporter = true;
    public bool canInput;
    public bool canExecute;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {

        if (target != null)
        {
            agent.SetDestination(target.position);
        }
        if(sendToTeleporterExecution)
        {
            SetDestinationExecutionTeleport();
            if (transform.position == teleportExecution.transform.position)
            {
                sendToTeleporterExecution = false;
                sendToCage = true;
            }
        }
        if(sendToCage)
        {
            SetDestinationExecutionSite();
        }

        if (canExecute)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                sendToCage = false;
                SetDestinationGuilotine();
                canExecute = false;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                sendToCage = false;
                SetDestinationCityTeleport();
                canExecute = false;
            }
        }
    }

    public void SetDestinationExecutionTeleport()
    {
        target = teleportExecution;
    }
    public void SetDestinationCityTeleport()
    {
        target = teleportCity;
    }
    public void SetDestinationExecutionSite()
    {
        target = executionSite;
    }
    public void SetDestinationGuilotine()
    {
        target = Guilotine;
    }
    public void SetDestinationBasePosition()
    {
        target = basePosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExecutionCage"))
        {
            canExecute = true;
        }
    }
}
