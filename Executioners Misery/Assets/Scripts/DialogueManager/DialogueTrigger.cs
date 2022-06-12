using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager _dialogueManager;
    public Dialogue dialogue;
    private bool hasInteracted;
    private bool colliderPlayer;
    [SerializeField] private AnimationManager animManager;



    private void Update()
    {
        if (colliderPlayer)
        {
            if (!_dialogueManager.IsTalking && hasInteracted == false && Input.GetKeyUp(KeyCode.E))
            {
                TriggerDialogue();
                hasInteracted = true;
            }
            if (Input.GetKeyDown(KeyCode.E) && hasInteracted)
            {
                animManager.Interact = true;
                animManager.Walk = false;
                animManager.Idle = false;
                _dialogueManager.DisplayNextSentence(dialogue);
            } 
        }
        else
        {
            hasInteracted = false;
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            colliderPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            colliderPlayer = false;
            animManager.Interact = false;
            animManager.Walk = false;
            animManager.Idle = true;
            _dialogueManager.EndDialogue();
        }
    }
}
