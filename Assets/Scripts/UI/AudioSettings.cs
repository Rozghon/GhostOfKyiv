using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private string _audioGroup;

    private void Awake()
    {
        if(PlayerPrefs.GetFloat(_audioGroup) == 0)
        {
            ChangeVolume(0);
        }
    }

    private void Start()
    {
        ChangeVolume(PlayerPrefs.GetFloat(_audioGroup));
    }

    public void ChangeVolume(float _volume)
    {
        _mixer.audioMixer.SetFloat(_audioGroup, _volume);
        PlayerPrefs.SetFloat(_audioGroup, _volume);
    }
}
