using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartButton : MonoBehaviour
{
    public SoundManager soundManager;
    AudioSource audioSource;
    float fadeDuration = 2;
    public bool isOption = false;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnClickExit()
    {
        SoundManager.Instance.audioSources[0].Play();
        Application.Quit();
    }
    public void OnClickStart()
    {

        SoundManager.Instance.audioSources[0].Play();
        SceneManager.LoadScene("BreakBlockTest");
    }
    public void OnClickOption()
    {
        SoundManager.Instance.audioSources[0].Play();
        isOption = true;
    }
    public void OnClickOptionExit()
    {
        SoundManager.Instance.audioSources[0].Play();
        isOption = false;
    }
}
