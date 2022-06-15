using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public DialogueAdjusted adjustDialogue;
    public GameObject startDoorEvent;

    private void OnTriggerEnter(Collider other)
    {
        adjustDialogue.ChangeDialogueTrigger();
    }

    private void OnTriggerExit(Collider other)
    {
        startDoorEvent.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
