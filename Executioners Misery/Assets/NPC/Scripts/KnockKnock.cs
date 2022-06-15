using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockKnock : MonoBehaviour
{
    public GameObject doorInteract;
    public GameObject doorObject;
    public AudioSource knockSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(KnockOnDoor());
        }
    }

    public IEnumerator KnockOnDoor()
    {
        yield return new WaitForSeconds(3f);
        knockSound.Play();
        yield return new WaitForSeconds(3f);
        doorObject.SetActive(true);
        knockSound.Stop();
        knockSound.Play();
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
}
