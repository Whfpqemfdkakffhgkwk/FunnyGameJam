using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlingShot : MonoBehaviour
{
    public Change change;
    bool DiceAnimation = false;

    void Update()
    {
        ChangeMode();
    }
    void ChangeMode()
    {
        if (change.changeMode == 1)
        {
            if (!DiceAnimation)
            {
                gameObject.transform.DOLocalMoveY(-2.2f, 0.25f).SetEase(Ease.Linear);
                StartCoroutine(changeModeCoroutine());

            }
            else
            {
                gameObject.transform.DOLocalMoveY(-3.5f, 0.5f).SetEase(Ease.Unset);
            }
        }
        else
        {
            DiceAnimation = false;
            gameObject.transform.DOLocalMoveY(-10.3f, 0.25f).SetEase(Ease.Linear);
        }
        IEnumerator changeModeCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("dd");
            DiceAnimation = true;
        }
    }
}
