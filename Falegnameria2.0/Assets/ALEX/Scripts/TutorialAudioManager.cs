using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{
    private AudioManager audioManager;
    public AudioClip buttonClickSound;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void PlayClickSound()
    {
        audioManager.PlaySFX(buttonClickSound);
    }
}
