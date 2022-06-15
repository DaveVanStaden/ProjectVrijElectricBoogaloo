using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkDissapear : MonoBehaviour
{
    public GameObject markSprite;
    public GameObject talkTrigger;

    private void OnTriggerExit(Collider other)
    {
        markSprite.SetActive(false);
        talkTrigger.SetActive(false);
    }
}
