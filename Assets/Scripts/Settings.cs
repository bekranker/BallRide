using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public Slider SoundSlider, MusicSlider;
    public AudioMixer _AudioMixer;
    private bool _didMuteMusic, _didMuteSound;
    public GameObject SettingsPanel;


    void Start()
    {
        ChangeSlidersVolue();
    }

    public void ChangeSlidersVolue()
    {
        if(PlayerPrefs.HasKey("Sound Volume"))
            SoundSliderF(PlayerPrefs.GetFloat("Sound Volume"));
        
        if(PlayerPrefs.HasKey("Music Volume"))
            MusicSliderF(PlayerPrefs.GetFloat("Music Volume"));
    }

    public void SoundSliderF(float value)
    {
        PlayerPrefs.SetFloat("Sound Volume", value);
        _AudioMixer.SetFloat("Sound", value);
        if (value == SoundSlider.minValue)
        {
            _didMuteSound = true;
        }
        else
            _didMuteSound = false;
    }
    public void MusicSliderF(float value)
    {
        PlayerPrefs.SetFloat("Music Volume", value);
        _AudioMixer.SetFloat("Music", value);
        if (value == MusicSlider.minValue)
            _didMuteMusic = true;
        else
            _didMuteMusic = false;
    }

    public void SetSound()
    {
        if (!PlayerPrefs.HasKey("Sound Volume"))
            PlayerPrefs.SetFloat("Sound Volume", SoundSlider.value);


        _didMuteSound = !_didMuteSound;


        if (_didMuteSound)
        {
            _AudioMixer.SetFloat("Sound", SoundSlider.value);
        }
        else
            _AudioMixer.SetFloat("Sound", -80);

    }
    public void SetMusic()
    {
        if (!PlayerPrefs.HasKey("Music Volume"))
            PlayerPrefs.SetFloat("Music Volume", SoundSlider.value);


        _didMuteMusic = !_didMuteMusic;


        if (_didMuteMusic)
        {
            _AudioMixer.SetFloat("Music", MusicSlider.value);
        }
        else
            _AudioMixer.SetFloat("Music", -80);

    }


    public void ClosePanel()
    {
        SettingsPanel.SetActive(false);
    }

}
