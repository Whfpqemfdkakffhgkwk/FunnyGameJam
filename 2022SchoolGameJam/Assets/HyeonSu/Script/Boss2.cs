using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Boss2 : MonoBehaviour
{
    int hp = 1000;
    private void Start()
    {
        gameObject.transform.DOMove(transform.position - new Vector3(0, 7f, 0), 1f);
        GameManager.Instance.RecallType = 1;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            //파티클 나올 예정

        }
        if (hp <= 0)
        {
            GameManager.Instance.RecallType = 0;
            Destroy(gameObject);
        }
    }
}
