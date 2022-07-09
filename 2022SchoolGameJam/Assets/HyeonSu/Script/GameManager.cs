using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyTypes;
    GameObject[] Enemys;
    int EnemyNum;
    [SerializeField] Transform[] EnemyRecallPoss;
    public void NextTurn()
    {
        Recall();
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemys.Length; i++)
        {
            Enemys[i].gameObject.transform.DOMove(Enemys[i].transform.position - new Vector3(0, 1.5f, 0), 1f);
        }
    }
    void Recall()
    {
        EnemyNum = Random.Range(1, 4);
        for (int i = 0; i < EnemyNum; i++)
        {
            int RandomRecallNum = Random.Range(0, 4);
            if (EnemyRecallPoss[RandomRecallNum] != null)
            {
                Instantiate(EnemyTypes[Random.Range(0,2)], EnemyRecallPoss[RandomRecallNum].localPosition,
                                    EnemyRecallPoss[RandomRecallNum].localRotation);
            }
            else
            {
                EnemyRecallPoss[RandomRecallNum] = null;
                i -= 1;
            }
        }
        for(int i = 0; i < 3; i++)
        {
            EnemyRecallPoss[i] = GameObject.Find($"Pos{i}").gameObject.transform;
        }
    }
}
