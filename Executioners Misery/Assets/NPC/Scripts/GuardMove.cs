using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMove : MonoBehaviour
{
    public GameObject nanSprite;

    private void OnTriggerExit(Collider other)
    {
        nanSprite.SetActive(false);
    }
}
