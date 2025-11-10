using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("UI References")]
    public Slider volumeSlider;
    public Toggle fullscreenToggle;

    [Header("Audio")]
    public AudioMixer audioMixer; // Lo creeremo tra poco

    private void Start()
    {
        // Imposta valori iniziali
        if (fullscreenToggle != null)
            fullscreenToggle.isOn = Screen.fullScreen;

        if (volumeSlider != null)
            volumeSlider.value = PlayerPrefs.GetFloat("volume", 1f);
        SetVolume(volumeSlider.value);
    }

    // Cambia volume
    public void SetVolume(float volume)
    {
        if (audioMixer != null)
        {
            audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("volume", volume);
        }
    }

    // Cambia fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Torna al menu
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
