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
    public Image SoundImage, MusicImage;

    public Sprite SoundSprite, MusicSprite, MutedSoundSprite, MutedMusicSprite;

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
            SoundImage.sprite = MutedSoundSprite;
            _didMuteSound = true;
        }
        else
        {
            _didMuteSound = false;
            SoundImage.sprite = SoundSprite;
        }
    }
    public void MusicSliderF(float value)
    {
        PlayerPrefs.SetFloat("Music Volume", value);
        _AudioMixer.SetFloat("Music", value);
        if (value == MusicSlider.minValue)
        {
            MusicImage.sprite = MutedMusicSprite;
            _didMuteMusic = true;
        }
        else
        {
            MusicImage.sprite = MusicSprite;
            _didMuteMusic = false;
        }
    }

    public void SetSound()
    {
        if (!PlayerPrefs.HasKey("Sound Volume"))
            PlayerPrefs.SetFloat("Sound Volume", SoundSlider.value);


        _didMuteSound = !_didMuteSound;


        if (_didMuteSound)
        {
            SoundImage.sprite = MutedSoundSprite;
            _AudioMixer.SetFloat("Sound", SoundSlider.value);
        }
        else
        {
            SoundImage.sprite = SoundSprite;
            _AudioMixer.SetFloat("Sound", -80);
        }

    }
    public void SetMusic()
    {
        if (!PlayerPrefs.HasKey("Music Volume"))
            PlayerPrefs.SetFloat("Music Volume", SoundSlider.value);


        _didMuteMusic = !_didMuteMusic;


        if (_didMuteMusic)
        {
            MusicImage.sprite = MutedMusicSprite;
            _AudioMixer.SetFloat("Music", MusicSlider.value);
        }
        else
        {
            MusicImage.sprite = MusicSprite;
            _AudioMixer.SetFloat("Music", -80);
        }

    }


    public void ClosePanel()
    {
        SettingsPanel.SetActive(false);
    }
    public void OpenPanel()
    {
        SettingsPanel.SetActive(true);
    }
}
