using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class ExecuteCharacter : MonoBehaviour
{
    public bool canExecute = false;
    private bool colidesWithPlayer;
    [SerializeField] private Text killText;
    public VideoPlayer videoPlayer;
    public GameObject UIPlayer;
    public AudioSource MusicExecutionSite;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && colidesWithPlayer)
        {
            StartCoroutine(startEndFilm());
            canExecute = false;
            colidesWithPlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canExecute)
        {
            if (other.CompareTag("Player"))
            {
                killText.gameObject.SetActive(true);
                colidesWithPlayer = true;
            }
            else
            {
                killText.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator startEndFilm()
    {
        UIPlayer.SetActive(true);
        videoPlayer.Play();
        MusicExecutionSite.Stop();
        yield return new WaitForSeconds(59);
        SceneManager.LoadScene("MainMenu");
    }
}
