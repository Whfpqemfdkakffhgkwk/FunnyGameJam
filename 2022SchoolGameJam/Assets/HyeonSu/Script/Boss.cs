using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Boss : MonoBehaviour
{
    private int hp = 1000;
    public int HP
    {
        get { return hp; }
        set
        {
            hp -= value;
            if (hp <= 0)
            {
                GameManager.Instance.maxRecall = 5;
                GameManager.Instance.minRecall = 1;
                Destroy(gameObject);
            }
        }
    }
    private void Start()
    {
        gameObject.transform.DOMove(transform.position - new Vector3(0, 8f, 0), 1f);
        GameManager.Instance.maxRecall = 6;
        GameManager.Instance.minRecall = 2;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("asd");
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            //파티클 나올 예정
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            HP = 50;
        }
    }
}
