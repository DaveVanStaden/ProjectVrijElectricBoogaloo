using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabNote : MonoBehaviour
{
    public GameObject foundPaper;
    public GameObject interactText;
    public GameObject leaveText;
    public GameObject noteCanvas;
    public GameObject noteObj;
    public GameObject dialoguePlayer;
    public bool isOpened;
    public bool isInside;


    private void Update()
    {
        if (isInside && !isOpened && Input.GetKeyUp(KeyCode.E))
        {
            foundPaper.SetActive(true);
            noteCanvas.SetActive(true);
            leaveText.SetActive(true);
            interactText.SetActive(false);
            isOpened = true;
        }

        if (isInside && isOpened && Input.GetKeyUp(KeyCode.F))
        {
            foundPaper.SetActive(false);
            noteCanvas.SetActive(false);
            leaveText.SetActive(false);
            interactText.SetActive(false);
            noteObj.SetActive(false);
            dialoguePlayer.SetActive(true);
            isOpened = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interactText.SetActive(true);
        if (other.gameObject.tag == "Player" && !isOpened)
        {
            isInside = true;
        }

        if (other.gameObject.tag == "Player" && isOpened)
        {
            isInside = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        interactText.SetActive(false);
        foundPaper.SetActive(false);
        leaveText.SetActive(false);
        noteCanvas.SetActive(false);
        interactText.SetActive(false);
        isOpened = false;
        isInside = false;
    }
}
