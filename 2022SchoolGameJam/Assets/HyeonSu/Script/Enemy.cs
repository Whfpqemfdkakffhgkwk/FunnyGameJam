using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public EnemyHpBar1 enemyHpBar1;
    public int Hp;
    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
        enemyHpBar1.slHP.value = Hp;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Hp = Hp - 50;
        }
    }
}
