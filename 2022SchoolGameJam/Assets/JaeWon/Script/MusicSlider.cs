using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicSlider : MonoBehaviour
{
    private void Start()
    {
        this.GetComponent<Scrollbar>().value = SoundManager.Instance.musicVolume;
    }
    public void Music(float value)
    {
        SoundManager.Instance.musicVolume = value;
    }
}
