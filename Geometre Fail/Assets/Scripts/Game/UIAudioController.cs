using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAudioController : MonoBehaviour
{
    [SerializeField] private Slider _sfxSlider;

    private void Awake()
    {
        _sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void SFXVolume()
    {
        PlayerPrefs.SetFloat("SFXVolume", _sfxSlider.value);
    }

    public void SaveSFXVolume()
    {
        AudioManager.Instance.SFXVolume(PlayerPrefs.GetFloat("SFXVolume"));
    }
}
