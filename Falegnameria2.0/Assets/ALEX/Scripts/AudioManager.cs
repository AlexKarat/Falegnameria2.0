using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

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

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
        // Cambia solo il volume, senza toccare mute o altro
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
        // Cambia solo il mute, senza toccare volume
        sfxSource.mute = !sfxOn;
        sfxButtonText.text = sfxOn ? "SFX Volume: ON" : "SFX Volume: OFF";
    }

    public void OnSFXSliderChanged()
    {
        // legge il valore dallo slider direttamente
        if (sfxSlider != null)
            SetSFXVolume(sfxSlider.value);
    }

    public void OnMusicSliderChanged()
    {
        if (musicSlider != null)
            SetMusicVolume(musicSlider.value);
    }

    public IEnumerator FadeOutMusic(float duration)
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume; // resetta volume per la prossima volta
    }

    public IEnumerator FadeInMusic(AudioClip newClip, float duration)
    {
        musicSource.clip = newClip;
        musicSource.volume = 0;
        musicSource.Play();

        while (musicSource.volume < 1)
        {
            musicSource.volume += Time.deltaTime / duration;
            yield return null;
        }

        musicSource.volume = 1;
    }

    public void OnStartButtonPressed()
    {
        StartCoroutine(TransitionToHub());
    }

    private IEnumerator TransitionToHub()
    {
        yield return StartCoroutine(FadeOutMusic(2f)); // 2 secondi di fade
        UnityEngine.SceneManagement.SceneManager.LoadScene("hubselection");
    }
}
