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


    public float MusicStartValue, SoundStartValue;


    void Start()
    {
        ChangeSlidersVolue(MusicStartValue, SoundStartValue);

        MusicSlider.value = MusicStartValue;
        SoundSlider.value = SoundStartValue;

    }

    public void ChangeSlidersVolue(float _MusicStartValue, float _SoundStartValue)
    {
        if (!PlayerPrefs.HasKey("Sound Volume"))
            SoundSliderF(_SoundStartValue);
        if (!PlayerPrefs.HasKey("Music Volume"))
            MusicSliderF(_MusicStartValue);
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
            _AudioMixer.SetFloat("Sound", -80);
        }
        else
        {
            SoundImage.sprite = SoundSprite;
            _AudioMixer.SetFloat("Sound", SoundSlider.value);
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
            _AudioMixer.SetFloat("Music", -80);
        }
        else
        {
            MusicImage.sprite = MusicSprite;
            _AudioMixer.SetFloat("Music", MusicSlider.value);
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
