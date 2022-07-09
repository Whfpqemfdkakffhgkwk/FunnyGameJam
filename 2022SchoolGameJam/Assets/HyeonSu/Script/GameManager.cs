using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [SerializeField] GameObject[] EnemyTypes, BossObjs;
    [SerializeField] GameObject Shields;
    GameObject[] Enemys;
    int EnemyNum;
    [SerializeField] Transform[] EnemyRecallPoss;
    int bossCheck = 0, bossType = 0;
    int a = 0; //for문 몇번 도는지 확인
    public int minRecall = 1, maxRecall = 5, RecallType = 0;
    private void Awake() => Instance = this;
    public void NextTurn()
    {
        Recall();
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemys.Length; i++)
        {
            Enemys[i].gameObject.transform.DOMove(Enemys[i].transform.position - new Vector3(0, 2f, 0), 1f);
        }
        if (GameObject.FindGameObjectWithTag("Boss") != null)
            GameObject.FindGameObjectWithTag("Boss").transform.DOMove
                (GameObject.FindGameObjectWithTag("Boss").transform.position - new Vector3(0, 1f, 0), 1f);

        if (bossCheck == 10)
        {
            bossCheck = 0;
            Instantiate(BossObjs[bossType], BossObjs[bossType].transform.position, BossObjs[bossType].transform.rotation);
            bossType++;
            if (bossType == 2)
                bossType = 0;
        }
        bossCheck++;
    }
    void Recall()
    {
        if (RecallType == 0)
        {
            EnemyNum = Random.Range(minRecall, maxRecall);
            for (int i = 0; i < EnemyNum; i++)
            {
                a++;
                int RandomRecallNum = Random.Range(0, 4);
                int RandomRecallType = Random.Range(0, 2);
                if (EnemyRecallPoss[RandomRecallNum] != null)
                {
                    Instantiate(EnemyTypes[RandomRecallType],
                                EnemyRecallPoss[RandomRecallNum].position + EnemyTypes[RandomRecallType].transform.localPosition,
                                EnemyTypes[RandomRecallType].transform.localRotation);
                    EnemyRecallPoss[RandomRecallNum] = null;
                }
                else
                    i -= 1;

                if (a == 5)
                    break;
            }
            for (int i = 0; i < 4; i++)
            {
                EnemyRecallPoss[i] = GameObject.Find($"Pos{i}").gameObject.transform;
            }

        }
        else if (RecallType == 1)
        {
            Instantiate(Shields, new Vector3(0, 10, 0), transform.rotation);
        }
    }
}
