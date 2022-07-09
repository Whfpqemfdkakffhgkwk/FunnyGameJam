using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObj : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject a = other.gameObject;
        switch (a.tag)
        {
            case "Bullet":
                GameManager.Instance.bulletNum--;
                Destroy(a);
                break;
            case "Enemy":
                Destroy(a);
                //���ӿ���
                break;
            case "Boss":
                Destroy(a);
                //���ӿ���
                break;
        }
    }
}
