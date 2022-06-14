using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWiggle : MonoBehaviour
{
    public Animator dogAnim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dogAnim.SetTrigger("IdleActive");
            dogAnim.ResetTrigger("WiggleTail");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            dogAnim.SetTrigger("WiggleTail");
            dogAnim.ResetTrigger("IdleActive");
        }
    }
}
