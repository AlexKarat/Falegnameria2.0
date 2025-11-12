using UnityEngine;

public class GameStartController : MonoBehaviour
{
    [Tooltip("Il pannello/oggetto StartButton (UI) che verrà nascosto quando si inizia")]
    public GameObject startButtonObj;

    [Tooltip("Riferimento al manager locale del minigioco (es. MiniGameLegnaManager o MiniGameSegaManager)")]
    public MonoBehaviour gameManagerWithStartMethod;

    // CHIAMARE questo metodo dal bottone UI
    public void OnStartButtonPressed()
    {
        // nascondi pulsante
        if (startButtonObj != null)
            startButtonObj.SetActive(false);

        // chiamiamo, se presente, il metodo StartGame nel manager
        // Il manager deve esporre public void StartGame()
        if (gameManagerWithStartMethod != null)
        {
            // Chiamiamo il metodo StartGame via reflection per comodità
            var method = gameManagerWithStartMethod.GetType().GetMethod("StartGame");
            if (method != null)
                method.Invoke(gameManagerWithStartMethod, null);
            else
                Debug.LogWarning("Il manager assegnato non contiene StartGame().");
        }
    }
}
