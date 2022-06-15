using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonnieShowup : MonoBehaviour
{
    public GameObject konnieChar;
    public GameObject bunnehOld;
    public GameObject bunnehNew;
    public GameObject amberOld;
    public GameObject amberNew;

    private void OnTriggerEnter(Collider other)
    {
        konnieChar.SetActive(true);
        bunnehOld.SetActive(false);
        bunnehNew.SetActive(true);
        amberOld.SetActive(false);
        amberNew.SetActive(true);
    }
}
