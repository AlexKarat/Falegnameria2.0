/// <summary>
/// Classe statica per memorizzare dati globali del gioco
/// che devono persistere tra un cambio di scena e l'altro.
/// Questo script NON va messo su nessun oggetto in scena.
/// </summary>
public static class StatoGioco
{
    /// <summary>
    /// Memorizza il nome della scena del minigioco
    /// da ricaricare quando si preme "Riavvia" nella scena GameOver.
    /// </summary>
    public static string ScenaDaRiavviare;

    // Puoi aggiungere altre variabili statiche qui se ti servono
    // ad esempio: public static int PunteggioGlobale;
}