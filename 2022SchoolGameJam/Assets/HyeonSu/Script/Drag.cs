using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private Vector3 firstPos;
    private Vector3 secondPos;
    private Vector3 gap;
    int a;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            firstPos = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            secondPos = Input.mousePosition;

            gap = firstPos - secondPos;
            if (a == 0)
            {
                Move();
            }
        }

    }
    void Move()
    {
        a++;
        GameManager.Instance.Shotpos = gap;
        if (gap != new Vector3(0, 0, 0))
        {
            GameManager.Instance.ShotConfirm = 1;
            GetComponent<Rigidbody>().AddForce(gap.normalized * 1000, ForceMode.Force);
        }
        else
            a = 0;
    }
}
