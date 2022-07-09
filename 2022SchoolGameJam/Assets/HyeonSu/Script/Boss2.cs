using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Boss2 : MonoBehaviour
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
                GameManager.Instance.RecallType = 0;
                Destroy(gameObject);
            }
        }
    }
    private void Start()
    {
        gameObject.transform.DOMove(transform.position - new Vector3(0, 8f, 0), 1f);
        GameManager.Instance.RecallType = 1;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            //파티클 나올 예정

        }
        else if(collision.gameObject.CompareTag("Bullet"))
        {
            hp = 50;
        }
    }
}
