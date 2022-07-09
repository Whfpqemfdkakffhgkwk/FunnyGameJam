using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleAnmation : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
            gameObject.transform.DOLocalMoveY(3f, 2f).SetEase(Ease.InOutQuint);
            StartCoroutine(wait());
            
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        gameObject.transform.DOLocalMoveY(2f, 2f).SetEase(Ease.InOutQuint);
    }
}
