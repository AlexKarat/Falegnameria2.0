using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("UI Elements")]
    public TMP_Text musicButtonText;
    public TMP_Text sfxButtonText;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Audio Clips")]
    public AudioClip buttonClickSound;

    private bool musicOn = true;
    private bool sfxOn = true;

    void Start()
    {
        UpdateMusicState();
        UpdateSFXState();
    }

    public void ToggleMusic()
    {
        musicOn = !musicOn;
        UpdateMusicState();
        PlaySFX(buttonClickSound);
    }

    public void ToggleSFX()
    {
        sfxOn = !sfxOn;
        UpdateSFXState();
        PlaySFX(buttonClickSound);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfxOn && clip != null)
            sfxSource.PlayOneShot(clip);
    }

    private void UpdateMusicState()
    {
        if (musicOn)
        {
            musicSource.Play();
            musicButtonText.text = "Musica: ON";
        }
        else
        {
            musicSource.Pause();
            musicButtonText.text = "Musica: OFF";
        }
    }

    private void UpdateSFXState()
    {
        sfxSource.mute = !sfxOn;
        sfxButtonText.text = sfxOn ? "SFX Volume: ON" : "SFX Volume: OFF";
    }
}
