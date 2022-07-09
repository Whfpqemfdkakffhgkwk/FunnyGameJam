using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public AudioSource[] audioSources;//0 ���, 1 ȿ����...
    public float musicVolume, EffVolume;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        Instance = this;
    }
    private void Update()
    {
        audioSources[0].GetComponent<AudioSource>().volume = EffVolume;
        audioSources[1].GetComponent<AudioSource>().volume = musicVolume;
    }
}
