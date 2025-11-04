using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void OnStartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

  
    public void OnTutorialButton()
    {
        SceneManager.LoadScene("MenuTutorial");
    }

    // Quando premi EXIT
    public void OnExitButton()
    {
        SceneManager.LoadScene("SampleScene");

    }
}
