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
                //게임오버
                break;
            case "Boss":
                Destroy(a);
                //게임오버
                break;
        }
    }
}
