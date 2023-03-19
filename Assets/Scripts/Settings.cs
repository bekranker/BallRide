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
        CheckMusic();
        CheckSound();
            
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
            PlayerPrefs.SetString("Muted Sound", "Muted Sound");
        }
        else
        {
            SoundImage.sprite = SoundSprite;
            _AudioMixer.SetFloat("Sound", SoundSlider.value);

                PlayerPrefs.DeleteKey("Muted Sound");
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
            PlayerPrefs.SetString("Muted Music", "Muted Music");
        }
        else
        {
            MusicImage.sprite = MusicSprite;
            _AudioMixer.SetFloat("Music", MusicSlider.value);
            if (PlayerPrefs.HasKey("Muted Music"))
                PlayerPrefs.DeleteKey("Muted Music");
        }

    }


    private void CheckMusic()
    {
        if (PlayerPrefs.HasKey("Music Volume"))
        {
            MusicSlider.value = PlayerPrefs.GetFloat("Music Volume");
            if (PlayerPrefs.HasKey("Muted Music"))
            {
                _AudioMixer.SetFloat("Music", -80);
                MusicImage.sprite = MutedMusicSprite;
                _didMuteMusic = !_didMuteMusic;
            }
            else
            {
                MusicImage.sprite = MusicSprite;
                _AudioMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music Volume"));
            }
        }
        else
        {
            _AudioMixer.SetFloat("Music", MusicStartValue);
            PlayerPrefs.SetFloat("Music Volume", MusicStartValue);
            MusicSlider.value = MusicStartValue;
        }

    }

    private void CheckSound()
    {
        if(PlayerPrefs.HasKey("Sound Volume"))
        {
            SoundSlider.value = PlayerPrefs.GetFloat("Sound Volume");
            if (PlayerPrefs.HasKey("Muted Sound"))
            {
                _AudioMixer.SetFloat("Sound", -80);
                SoundImage.sprite = MutedSoundSprite;
                _didMuteSound = !_didMuteSound;
            }
            else
            {
                SoundImage.sprite = SoundSprite;
                _AudioMixer.SetFloat("Sound", PlayerPrefs.GetFloat("Sound Volume"));
            }   
        }
        else
        {
            _AudioMixer.SetFloat("Sound", SoundStartValue);
            PlayerPrefs.SetFloat("Sound Volume", SoundStartValue);
            SoundSlider.value = SoundStartValue;
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
