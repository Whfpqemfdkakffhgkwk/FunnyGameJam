using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{
    [SerializeField]    public int changeMode = -1;
    public void changeButton()
    {
            changeMode = (changeMode) * (-1);
    }
}
