using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer MainMixer;
    public AudioSource Background;
    public AudioSource Ombak;
    public Dropdown ResolutionDropDown;

    Resolution[] resolutions;




    public void SetResolution(int resolusiIndex)
    {
        Resolution resolution = resolutions[resolusiIndex];
        Screen.SetResolution(resolution.height, resolution.width, Screen.fullScreen);
    }

    public void SetVol(float Volume)
    {
        MainMixer.SetFloat("Volume", Volume);
        Debug.Log(Volume);

    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetMute(bool IsMute)
    {
        AudioSource music = Background.GetComponent<AudioSource>();
        AudioSource soundeffect = Ombak.GetComponent<AudioSource>();
        music.ignoreListenerVolume = IsMute;
        soundeffect.ignoreListenerVolume = IsMute;
        soundeffect.volume *= 0f;
        music.volume *= 0f;
    }
}
