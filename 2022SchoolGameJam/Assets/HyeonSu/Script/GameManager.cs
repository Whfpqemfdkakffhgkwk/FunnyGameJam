using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    [SerializeField] Text Roun, Sho;
    [SerializeField] GameObject[] EnemyTypes, BossObjs;
    [SerializeField] GameObject Shields, ball, StartBall, Select;
    [SerializeField] GameObject SlingshotObj, DiceObj;
    GameObject[] Enemys;
    int EnemyNum, roundcheck;
    float ff = 0.2f;
    [SerializeField] Transform[] EnemyRecallPoss;
    public Vector3 Shotpos; 
    int bossCheck = 0, bossType = 0;
    int a = 0; //for문 몇번 도는지 확인
    public int minRecall = 1, maxRecall = 5, RecallType = 0, bulletNum = 1, DeletebulletNum = 0, ShotConfirm = 0;
    private void Awake() => Instance = this;
    private void Start()
    {
        NextTurn();
    }
    private void Update()
    {
        Roun.text = $"{roundcheck}";
        Sho.text = $"{bulletNum}";
        if(bulletNum == DeletebulletNum)
        {
            NextTurn();
            ff = 0.2f;
            DeletebulletNum = 0;
        }
        if(ShotConfirm == 1)
        {
            for (int i = 0; i < bulletNum - 1; i++)
            {
                ff += 0.2f;
                StartCoroutine(Shooting());
            }
            ShotConfirm = 0;
        }
    }
    public void NextTurn()
    {
        roundcheck++;
        Select.SetActive(true);
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
    public void Slingshot()
    {
        Instantiate(StartBall, new Vector3(0.177f, -4.42f, 0), transform.rotation);
        SlingshotObj.SetActive(true);
        DiceObj.SetActive(false);
    }
    public void Dice()
    {
        SlingshotObj.SetActive(false);
        DiceObj.SetActive(true);
    }
    IEnumerator Shooting()
    {
            yield return new WaitForSeconds(ff);
            Debug.Log("asd");
            GameObject a = Instantiate(ball, new Vector3(0.177f, -4.42f, 0), transform.rotation);
            a.GetComponent<Rigidbody>().AddForce(Shotpos.normalized * 1000, ForceMode.Force);
    }
}
