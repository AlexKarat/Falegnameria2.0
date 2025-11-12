using UnityEngine;

public class HubMusicTrigger : MonoBehaviour
{
    public AudioClip hubMusic;

    void Start()
    {
        AudioManager am = FindFirstObjectByType<AudioManager>();
        if (am != null)
            am.StartCoroutine(am.FadeInMusic(hubMusic, 2f));
    }
}
