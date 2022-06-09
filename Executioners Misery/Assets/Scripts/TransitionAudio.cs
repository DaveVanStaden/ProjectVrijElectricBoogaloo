using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source1, source2;

    public void FadeAudio()
    {
        StopAllCoroutines();
        StartCoroutine(FadeTrack());
    }

    private IEnumerator FadeTrack()
    {
        float timeToFade = 3.5f;
        float timeElapsed = 0;

        while (timeElapsed < timeToFade)
        {
            source2.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
            source1.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
