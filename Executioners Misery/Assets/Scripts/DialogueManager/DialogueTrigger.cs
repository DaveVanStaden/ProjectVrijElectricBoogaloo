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
    public bool hasAnimations;
    public GameObject interactUI;
    [SerializeField] private AnimationManager animManager;
    [SerializeField] private AIAnimationController aiAnimManager;
    [SerializeField] private AIExecution AI;



    private void Update()
    {
        if (colliderPlayer)
        {
            if (!_dialogueManager.IsTalking && hasInteracted == false && hasAnimations && Input.GetKeyUp(KeyCode.E))
            {
                TriggerDialogue();
                AI.DialogueStartText.gameObject.SetActive(false);
                animManager.Interact = true;
                animManager.Walk = false;
                animManager.Idle = false;
                aiAnimManager.Talk = true;
                aiAnimManager.Walk = false;
                aiAnimManager.Idle = false;
                hasInteracted = true;
            }

            if (!_dialogueManager.IsTalking && hasInteracted == false && !hasAnimations && Input.GetKeyUp(KeyCode.E))
            {
                TriggerDialogue();
                AI.DialogueStartText.gameObject.SetActive(false);
                hasInteracted = true;
                interactUI.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.E) && hasInteracted && hasAnimations)
            {
                _dialogueManager.DisplayNextSentence(dialogue);
            } 
            if(Input.GetKeyDown(KeyCode.E) && hasInteracted && !hasAnimations)
            {
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
            interactUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && hasAnimations)
        {
            colliderPlayer = false;
            animManager.Interact = false;
            animManager.Walk = false;
            animManager.Idle = true;
            _dialogueManager.EndDialogue();
            interactUI.SetActive(false);
        }

        if (other.gameObject.tag == "Player" && !hasAnimations)
        {
            colliderPlayer = false;
            _dialogueManager.EndDialogue();
            interactUI.SetActive(false);
        }
    }
}
