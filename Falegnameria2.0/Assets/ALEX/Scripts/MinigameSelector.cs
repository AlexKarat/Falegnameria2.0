using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameSelector : MonoBehaviour
{
    private AudioManager audioManager;

    public AudioClip[] miniGameSounds; // Un suono per ogni minigioco

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void SelectMiniGame(int index)
    {
        // Riproduci suono del minigioco scelto
        if (miniGameSounds != null && index < miniGameSounds.Length)
        {
            audioManager.PlaySFX(miniGameSounds[index]);
        }

        // Carica la scena del minigioco (o tutorial)
        SceneManager.LoadScene("TutorialScene_" + index);
        //  poi la personalizzi tu con i nomi delle tue scene reali
    }
}
