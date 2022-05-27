using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText;
    public Text nameText;
    public GameObject hintText;

    public Animator animator;
    public bool IsTalking;
    private bool isPlayer = false;
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        hintText.gameObject.SetActive(true);
        if (dialogue.IsForester)
        {
            
        }
        animator.SetBool("isOpen", true);
        IsTalking = true;
        nameText.text = dialogue.name;
        
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(dialogue);
    }

    public void DisplayNextSentence(Dialogue dialogue)
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            if (dialogue.IsForester)
            {
                
            }

            if (dialogue.isEnding)
            {
                
            }
            return;
        }
        
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        if (dialogue.playerTalkingBack)
        {
            if (isPlayer)
            {
                nameText.text = dialogue.playerName;
                isPlayer = false;
            }
            else
            {
                nameText.text = dialogue.name;
                isPlayer = true;
            }
        }
        else
        {
            nameText.text = dialogue.name;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = " ";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void EndDialogue()
    {
        hintText.gameObject.SetActive(false);
        IsTalking = false;
        isPlayer = false;
        nameText.text = "";
        dialogueText.text = "";
        animator.SetBool("isOpen", false);
    }
}
