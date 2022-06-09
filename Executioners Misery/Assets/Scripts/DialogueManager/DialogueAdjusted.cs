using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAdjusted : MonoBehaviour
{
    public string[] sentenceHoldingCell;
    public string[] BaseSentence;
    [SerializeField] private DialogueTrigger trigger;

    public void changeHoldingCell()
    {
        trigger.dialogue.sentences = sentenceHoldingCell;
    }
    public void ChangeBaseSentence()
    {
        trigger.dialogue.sentences = BaseSentence;
    }
}
