using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceButton : MonoBehaviour
{
    
    public bool isInputDiceButton = false;

    public void InputButton()
    {
        if (isInputDiceButton == false)
        {
            isInputDiceButton = true;
            Debug.Log("버튼 눌림");
        }
    }
}
