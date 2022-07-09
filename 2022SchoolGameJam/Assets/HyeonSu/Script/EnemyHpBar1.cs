using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Silder class ����ϱ� ���� �߰��մϴ�.

public class EnemyHpBar1 : MonoBehaviour
{
    
    [HideInInspector]
    public Slider slHP;
    float fSliderBarTime;
    public Vector3 Vec3;
    void Start()
    {
        slHP = GetComponent<Slider>();
    }


    void Update()
    {
        this.gameObject.transform.position = Camera.main.WorldToScreenPoint(transform.parent.transform.parent.position) - Vec3;
        if (slHP.value <= 0)
        {
            Destroy(gameObject);
        }
    }
}

