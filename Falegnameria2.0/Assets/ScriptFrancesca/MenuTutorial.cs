using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTutorial : MonoBehaviour
{
    public void OnBackButton()
    {
        SceneManager.LoadScene("MenuGioco");
    }
}
