using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public void PlayClickSound()
    {
        FindFirstObjectByType<AudioManager>().PlaySFX(
            FindFirstObjectByType<AudioManager>().buttonClickSound
        );
    }
}
