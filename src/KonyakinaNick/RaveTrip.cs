namespace KonyakinaNick;

/// <summary>
/// A weekend away. Helga loves two of them: "Skhema" in Kyiv and
/// "Povitrya" in Odessa. Bass, sunrises, and material for the next animation.
/// </summary>
public sealed record RaveTrip(string Event, string City, int Nights)
{
    /// <summary>Energy spent, in percent of a fully-charged Helga.</summary>
    public int EnergySpent => Math.Min(100, Nights * 60);

    /// <summary>She never leaves a deadline behind — designs shipped before the train.</summary>
    public int DesignsShippedFirst => Math.Max(1, Nights);

    public string Summary()
    {
        var vibe = City switch
        {
            "Kyiv"   => "concrete, strobes, and a crowd that knows the drop.",
            "Odessa" => "the sea at your back and a sunrise over the decks.",
            _        => "wherever the good sound is."
        };
        return $"{Nights} night(s) at {Event}, {City} — {vibe}\n" +
               $"Designs shipped before leaving: {DesignsShippedFirst}. " +
               $"Energy at the end: {100 - EnergySpent}%.\n" +
               "She'll be back with a full camera roll and a new colour palette. 🎨";
    }
}
