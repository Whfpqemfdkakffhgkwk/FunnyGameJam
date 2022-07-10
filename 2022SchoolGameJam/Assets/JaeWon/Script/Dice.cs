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
    [SerializeField] GameObject[] DicePart;
    Vector3[] DiceNumVecs = { new Vector3(286.4f, 0, 0), new Vector3(104.17f, 0, 0), new Vector3(0, 270.3f, -24), new Vector3(0, 8, 0), new Vector3(0, 89.06f, 12.54f), new Vector3(191.96f, 0, 0) };
    void Start()
    {
        RandomNum = Random.Range(0, 6);
    }

    public void DiceReRole()
    {
            isDice = false;
            RandomNum = Random.Range(0, 6);
            y = Random.Range(1500, 3000);
            gameObject.transform.DORotate(new Vector3(0, y, 0), 2f, RotateMode.LocalAxisAdd);
            StartCoroutine(DiceNumRotate());
    }

    IEnumerator DiceNumRotate()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 8; i++)
        {
            DicePart[i].transform.DORotate(DiceNumVecs[RandomNum], 3f);
        }
        StartCoroutine(DiceNumRotateReset());
    }
    IEnumerator DiceNumRotateReset()
    {
        yield return new WaitForSeconds(0.5f);
        diceButton.isInputDiceButton = false;
        isDice = true;
        yield return new WaitForSeconds(2.5f);
        GameManager.Instance.bulletNum += (RandomNum + 1);
        Debug.Log(GameManager.Instance.bulletNum);
        GameManager.Instance.NextTurn();
    }

}
