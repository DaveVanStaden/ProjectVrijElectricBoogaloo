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
            _execution.sendToCage = true;
            isInCity = false;
        } else if (other.CompareTag("Teleporter") && !isInCity)
        {
            _execution.SetDestinationBasePosition();
            _execution.canSendToTeleporter = true;
            _execution.sendToTeleporterCity = false;
            isInCity = true;
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
