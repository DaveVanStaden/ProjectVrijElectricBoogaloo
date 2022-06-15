using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNavigation : MonoBehaviour
{
    [SerializeField] private AIExecution _execution;
    [SerializeField] private TeleportAI teleport;
    [SerializeField] private GameObject teleportCity;
    [SerializeField] private GameObject teleportExecution;
    public ExecuteCharacter executeEnding;
    public bool isInCity = true;
    public bool goToCell;
    public bool goExecute;
    public bool goesAway;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _execution.canInput)
        {
            _execution.sendToTeleporterExecution = true;
            _execution.canSendToTeleporter = false;
            goesAway = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _execution.canSendToTeleporter)
        {
            _execution.canInput = true;
            _execution.StartPlaceText.gameObject.SetActive(true);
            _execution.DialogueStartText.gameObject.SetActive(true);
        }
        else
        {
            _execution.canInput = false;
        }
        if (other.CompareTag("Teleporter") && isInCity && goesAway)
        {
            _execution.sendToTeleporterExecution = false;
            _execution.sendToCellTeleport = true;
            isInCity = false;
            goToCell = true;
            goesAway = false;
        }
        if (other.CompareTag("Teleporter") && !isInCity && !goToCell && _execution.canReturn && !_execution.canExecute &&!_execution.isExecuting)
        {
            _execution.SetDestinationBasePosition();
            _execution.canSendToTeleporter = true;
            _execution.sendToTeleporterCity = false;
            _execution.canReturn = false;
            isInCity = true;
        }

        if (other.CompareTag("Teleporter") && !isInCity && goToCell && !_execution.canExecute)
        {
            _execution.SetDestinationCellTeleport();
            _execution.sendToCage = true;
            _execution.sendToCellTeleport = false;
            goToCell = false;
        }

        if (other.CompareTag("Teleporter") && _execution.isExecuting)
        {
            _execution.SetDestinationGuilotine();
        }

        if (other.CompareTag("Guilotine"))
        {
            _execution.animController.Idle = true;
            _execution.animController.Walk = false;
            _execution.animController.Talk = false;
            executeEnding.canExecute = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _execution.canSendToTeleporter)
        {
            _execution.canInput = false;
        }

        if (other.CompareTag("Player"))
        {
            _execution.StartPlaceText.gameObject.SetActive(false);
            _execution.DialogueStartText.gameObject.SetActive(false);
        }
    }
}
