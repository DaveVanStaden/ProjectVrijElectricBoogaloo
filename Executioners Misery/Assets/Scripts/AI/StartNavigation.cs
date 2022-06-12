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
    public bool isInCity = true;
    public bool goToCell;
    public bool goExecute;
    public bool isInCell;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _execution.canInput)
        {
            _execution.sendToTeleporterExecution = true;
            _execution.canSendToTeleporter = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _execution.canSendToTeleporter)
        {
            _execution.canInput = true;
        }
        else
        {
            _execution.canInput = false;
        }
        if (other.CompareTag("Teleporter") && isInCity)
        {
            _execution.sendToTeleporterExecution = false;
            _execution.sendToCellTeleport = true;
            isInCity = false;
            goToCell = true;
        }
        if (other.CompareTag("Teleporter") && !isInCity && !goToCell)
        {
            _execution.SetDestinationBasePosition();
            _execution.canSendToTeleporter = true;
            _execution.sendToTeleporterCity = false;
            isInCity = true;
        }

        if (other.CompareTag("Teleporter") && !isInCity && goToCell)
        {
            _execution.SetDestinationCellTeleport();
            //_execution.sendToCage = true;
            _execution.sendToCellTeleport = false;
            goToCell = false;
            isInCell = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _execution.canSendToTeleporter)
        {
            _execution.canInput = false;
        }
    }
}
