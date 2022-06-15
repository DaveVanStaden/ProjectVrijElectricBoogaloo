using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBreak : MonoBehaviour
{
    public GameObject windowPane;
    public Animator brickAnim;
    public ParticleSystem glassShards;

    public AudioSource breakSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(BreakWindow());
        }
    }

    public IEnumerator BreakWindow()
    {
        brickAnim.SetTrigger("BrickThrow");
        yield return new WaitForSeconds(0.18f);
        breakSound.Play();
        yield return new WaitForSeconds(0.1f);
        windowPane.SetActive(false);
        glassShards.Play();
        this.gameObject.SetActive(false);
    }
}
