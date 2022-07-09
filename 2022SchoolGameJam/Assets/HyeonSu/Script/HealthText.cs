using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthText : MonoBehaviour
{
    TextMeshProUGUI resourceText;

    public Enemy enemy;
    float fSliderBarTime;
    public Vector3 Vec3;
    void Start()
    {
        resourceText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        this.gameObject.transform.position = Camera.main.WorldToScreenPoint(transform.parent.transform.parent.position) - Vec3;
        resourceText.transform.position = Camera.main.WorldToScreenPoint(transform.parent.transform.parent.position) - Vec3;
        resourceText.text = enemy.Hp.ToString();
        if (enemy.Hp <= 0)
        {
            Destroy(gameObject);
        }   
    }
}
