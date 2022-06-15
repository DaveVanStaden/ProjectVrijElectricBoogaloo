using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimOpen : MonoBehaviour
{
    public GameObject foundPaper;
    public GameObject interactText;
    public GameObject leaveText;
    public GameObject noteCanvas;
    public GameObject finalTalk;
    public GameObject streetTeleporter;
    public Animator doorOpen;
    public bool isInside;
    public bool isOpened;

    private void Update()
    {
        if (isInside && Input.GetKeyUp(KeyCode.E))
        {
            doorOpen.SetTrigger("OpenDoor");
            foundPaper.SetActive(true);
            interactText.SetActive(false);
            leaveText.SetActive(true);
            noteCanvas.SetActive(true);
            isOpened = true;
        }

        if (isInside && isOpened && Input.GetKeyUp(KeyCode.F))
        {
            doorOpen.SetTrigger("CloseDoor");
            foundPaper.SetActive(false);
            noteCanvas.SetActive(false);
            leaveText.SetActive(false);
            interactText.SetActive(false);
            finalTalk.SetActive(true);
            StartCoroutine(OpenStreetDoor());
            isInside = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        interactText.SetActive(true);
        if (other.gameObject.tag == "Player" && !isOpened)
        {
            isInside = true;
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

    public IEnumerator OpenStreetDoor()
    {
        yield return new WaitForSeconds(12f);
        streetTeleporter.SetActive(true);
        finalTalk.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
