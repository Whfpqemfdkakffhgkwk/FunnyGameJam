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
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnClickExit()
    {
        soundManager.PlaySound("JUMP");
        Application.Quit();
    }
    public void OnClickStart()
    {

        soundManager.PlaySound("JUMP");
        SceneManager.LoadScene("BreakBlockTest");
    }
}
