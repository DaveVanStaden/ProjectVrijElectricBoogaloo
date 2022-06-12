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
    public Transform cellTeleport;
    public Transform executionFromCellTeleport;
    public DialogueAdjusted adjustDialogue;
    private NavMeshAgent agent;
    
    public bool sendToCage;
    public bool sendToCellTeleport;
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
                sendToCellTeleport = true;
            }
        }

        if (sendToCellTeleport)
        {
            SetDestinationCellTeleport();
            if (transform.position == cellTeleport.transform.position)
            {
                sendToCellTeleport = false;
                sendToCage = true;
            }
        }
        if(sendToCage)
        {
            SetDestinationExecutionSite();
            adjustDialogue.changeHoldingCell();
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
                SetDestinationExecutionTeleportFromCell();
                adjustDialogue.ChangeBaseSentence();
                canExecute = false;
                sendToTeleporterCity = true;
            }
        }

        if (sendToTeleporterCity)
        {
            SetDestinationCityTeleport();
            if (transform.position == teleportCity.transform.position)
            {
                sendToTeleporterCity = false;
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
    public void SetDestinationCellTeleport()
    {
        target = cellTeleport;
    }
    public void SetDestinationExecutionTeleportFromCell()
    {
        target = executionFromCellTeleport;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExecutionCage"))
        {
            canExecute = true;
        }
    }
}
