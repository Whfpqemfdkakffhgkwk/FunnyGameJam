using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dice : MonoBehaviour
{
    public DiceButton diceButton;
    public Change change;
    float DiceTime;
    int x, y, z;
    int RandomNum = 0;
    bool isDice = true;
    public bool DiceAnimation = false;
    Vector3[] DiceNumVecs = {new Vector3(24,0,0), new Vector3(0, 118, 0), new Vector3(114, 0, 0), new Vector3(204, 0, 0), new Vector3(294, 0, 0), new Vector3(0, 298, 0) };
    void Start()
    {
        RandomNum = Random.Range(0, 6);
    }
    void Update()
    {
        DiceReRole();
        ChangeMode();
    }

    void DiceReRole()
    {
        if (diceButton.isInputDiceButton == true && isDice == true)
        {
            x = Random.Range(700, 1000);
            y = Random.Range(700, 1000);
            z = Random.Range(700, 1000);
            gameObject.transform.DORotate(new Vector3(x, y, z), 2f, RotateMode.LocalAxisAdd);
            isDice = false;
            StartCoroutine(DiceNumRotate());
        }
    }
    void ChangeMode()
    {
        if(change.changeMode == -1)
        {
            if (!DiceAnimation)
            {
                gameObject.transform.DOLocalMoveY(-1.2f, 0.25f).SetEase(Ease.Linear);
                StartCoroutine(changeModeCoroutine());

            }
            else
            {
                gameObject.transform.DOLocalMoveY(-1.5f, 0.5f).SetEase(Ease.Unset);
            }
        }
        else
        {
            DiceAnimation = false;
            gameObject.transform.DOLocalMoveY(-10.3f, 0.25f).SetEase(Ease.Linear);
            diceButton.isInputDiceButton = false;
            isDice = false;
        }
    }

    IEnumerator DiceNumRotate()
    {
        yield return new WaitForSeconds(2f);
        RandomNum = Random.Range(0, 6);
        gameObject.transform.DORotate(DiceNumVecs[RandomNum], 3f);
        StartCoroutine(DiceNumRotateReset());
    }
    IEnumerator DiceNumRotateReset()
    {
        yield return new WaitForSeconds(1f);
        diceButton.isInputDiceButton = false;
        isDice = true;
    }

    IEnumerator changeModeCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("dd");
        diceButton.isInputDiceButton = false;
        isDice = true;
        DiceAnimation = true;
    }
}
