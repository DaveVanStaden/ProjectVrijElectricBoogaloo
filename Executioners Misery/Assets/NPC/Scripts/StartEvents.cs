using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvents : MonoBehaviour
{
    public GameObject windowEvent;

    private void OnTriggerEnter(Collider other)
    {
        windowEvent.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
