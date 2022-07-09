using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectSlider : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Scrollbar>().value = SoundManager.Instance.EffVolume;
    }
    public void Music(float value)
    {
        SoundManager.Instance.EffVolume= value;
    }
}
