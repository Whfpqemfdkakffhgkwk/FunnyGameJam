using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OptionButton : MonoBehaviour
{
    public StartButton startButton;
    void Start()
    {
        
    }

    void Update()
    {
        if(startButton.isOption == true)
        {
            gameObject.transform.DOLocalMoveY(-10f, 0.25f).SetEase(Ease.Linear);
        }
        else if (startButton.isOption == false)
        {
            gameObject.transform.DOLocalMoveY(-10000f, 0.25f).SetEase(Ease.Linear);
            gameObject.transform.position = new Vector3(700, -100000, 0);
        }
    }

}
