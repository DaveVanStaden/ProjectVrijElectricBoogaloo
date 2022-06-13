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
    public AIAnimationController animController;
    public GateAnimationManager animGateController;
    
    public bool sendToCage;
    public bool sendToCellTeleport;
    public bool sendToTeleporterExecution;
    public bool sendToTeleporterCity;
    public bool canSendToTeleporter = true;
    public bool canInput;
    public bool canExecute;
    public bool canReturn;
    public bool isExecuting;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animController.Idle = true;
        animController.Walk = false;
        animController.Talk = false;
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
        if(sendToCage && !canExecute)
        {
            SetDestinationExecutionSite();
            adjustDialogue.changeHoldingCell();
        }

        if (canExecute)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                sendToCage = false;
                SetDestinationExecutionTeleportFromCell();
                animGateController.Open = true;
                StartCoroutine(gateOpenClose(target));
                isExecuting = true;
                canExecute = false;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                sendToCage = false;
                SetDestinationExecutionTeleportFromCell();
                animGateController.Open = true;
                StartCoroutine(gateOpenClose(target));
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
        animController.Walk = true;
        animController.Idle = false;
        animController.Talk = false;
    }
    public void SetDestinationCityTeleport()
    {
        target = teleportCity;
        animController.Walk = true;
        animController.Idle = false;
        animController.Talk = false;
    }
    public void SetDestinationExecutionSite()
    {
        target = executionSite;
        animController.Walk = true;
        animController.Idle = false;
        animController.Talk = false;
    }
    public void SetDestinationGuilotine()
    {
        target = Guilotine;
        animController.Walk = true;
        animController.Idle = false;
        animController.Talk = false;
    }
    public void SetDestinationBasePosition()
    {
        target = basePosition;
        animController.Walk = true;
        animController.Idle = false;
        animController.Talk = false;
    }
    public void SetDestinationCellTeleport()
    {
        target = cellTeleport;
        animController.Walk = true;
        animController.Idle = false;
        animController.Talk = false;
    }
    public void SetDestinationExecutionTeleportFromCell()
    {
        target = executionFromCellTeleport;
        animController.Walk = true;
        animController.Idle = false;
        animController.Talk = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ExecutionCage"))
        {
            canReturn = true;
            canExecute = true;
            animController.Idle = true;
            animController.Talk = false;
            animController.Walk = false;
            
        }
    }

    public IEnumerator gateOpenClose(Transform currentTarget)
    {
        target = null;
        yield return new WaitForSeconds(2);
        target = currentTarget;
        animGateController.Open = false;

    }
}
