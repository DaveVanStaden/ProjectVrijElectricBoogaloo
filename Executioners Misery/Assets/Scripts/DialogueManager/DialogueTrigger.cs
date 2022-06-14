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
    [SerializeField] private AnimationManager animManager;
    [SerializeField] private AIAnimationController aiAnimManager;



    private void Update()
    {
        if (colliderPlayer)
        {
            if (!_dialogueManager.IsTalking && hasInteracted == false && Input.GetKeyUp(KeyCode.E))
            {
                TriggerDialogue();
                hasInteracted = true;
            }
            if (Input.GetKeyDown(KeyCode.E) && hasInteracted && hasAnimations)
            {
                animManager.Interact = true;
                animManager.Walk = false;
                animManager.Idle = false;
                aiAnimManager.Talk = true;
                aiAnimManager.Walk = false;
                aiAnimManager.Idle = false;
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
        }

        if (other.gameObject.tag == "Player" && !hasAnimations)
        {
            colliderPlayer = false;
            _dialogueManager.EndDialogue();
        }
    }
}
