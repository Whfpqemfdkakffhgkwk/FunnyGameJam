using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] Enemys; 
    public void NextTurn()
    {
        Recall();
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < Enemys.Length; i++)
        {

        }
    }
    void Recall()
    {

    }
}
