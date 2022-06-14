using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public Animator hoeAnim;
    public GameObject triggerBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hoeAnim.SetTrigger("HeadBob");
            hoeAnim.ResetTrigger("IdleActive");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            hoeAnim.SetTrigger("IdleActive");
            hoeAnim.ResetTrigger("HeadBob");
            //triggerBox.SetActive(false);
        }
    }
}
