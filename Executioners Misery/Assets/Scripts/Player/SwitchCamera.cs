using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    public GameObject turnOn;
    public GameObject turnOff;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            turnOff.SetActive(false);
            turnOn.SetActive(true);
        }
    }
}
