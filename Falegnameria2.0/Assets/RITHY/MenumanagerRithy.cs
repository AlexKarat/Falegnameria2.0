using UnityEngine;
using UnityEngine.SceneManagement;

public class HubManager : MonoBehaviour
{
    [Header("Nomi delle Scene dei MENU dei minigiochi")]
    public string menuGuanti = "MenuGiocoGuanti";
    public string menuLegno = "MenuGiocoLegno";
    public string menuSega = "MenuGiocoSegaCircolare"; // oppure "MenuGiocoSega" se la tua scena si chiama così
    public string menuOcchiali = "MenuGiocoOcchiali";

    // --- Metodi collegabili ai pulsanti ---

    public void ApriMenuGuanti()
    {
        Debug.Log("Apro il menu del minigioco: " + menuGuanti);
        SceneManager.LoadScene(menuGuanti);
    }

    public void ApriMenuLegno()
    {
        Debug.Log("Apro il menu del minigioco: " + menuLegno);
        SceneManager.LoadScene(menuLegno);
    }

    public void ApriMenuSega()
    {
        Debug.Log("Apro il menu del minigioco: " + menuSega);
        SceneManager.LoadScene(menuSega);
    }

    public void ApriMenuOcchiali()
    {
        Debug.Log("Apro il menu del minigioco: " + menuOcchiali);
        SceneManager.LoadScene(menuOcchiali);
    }
}
