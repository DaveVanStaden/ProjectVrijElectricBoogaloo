using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMike : MonoBehaviour
{
    public GameObject mikeSpriteOld;
    public GameObject mikeSpriteNew;
    public GameObject bunnehSprite;

    private void OnTriggerExit(Collider other)
    {
        mikeSpriteNew.SetActive(true);
        mikeSpriteOld.SetActive(false);
        bunnehSprite.SetActive(true);
    }
}
