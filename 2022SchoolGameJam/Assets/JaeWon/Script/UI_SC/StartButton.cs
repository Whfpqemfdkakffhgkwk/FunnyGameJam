using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class StartButton : MonoBehaviour
{
    public void OnClickExit()
    {
        Application.Quit();
    }
    public void OnClickStart()
    {
        SceneManager.LoadScene("BreakBlockTest");
    }
}
