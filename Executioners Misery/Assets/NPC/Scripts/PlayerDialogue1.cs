using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue1 : MonoBehaviour
{
    public GameObject dialoguePlayer;

    private void OnTriggerEnter(Collider other)
    {
        dialoguePlayer.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
