namespace KonyakinaNick;

/// <summary>
/// The little world behind the TV set on Konyakina street:
/// Nickelodeon reruns, Helga's moods, and a design desk that never sleeps.
/// A love letter, disguised as a console app. 💛
/// </summary>
public static class Studio
{
    // In this house the beloved "football head" is you.
    public const string Arnold = "Arnold";

    private static readonly Random Rng = new();

    private static readonly string[] Shows =
    {
        "Hey Arnold!", "Rugrats", "SpongeBob SquarePants", "The Wild Thornberrys",
        "Rocket Power", "CatDog", "The Angry Beavers", "Aaahh!!! Real Monsters",
        "Kenan & Kel", "Doug", "The Fairly OddParents", "Danny Phantom",
        "Avatar: The Last Airbender", "Invader Zim"
    };

    /// <summary>Flip to a channel. Whatever it lands on, it was the 90s. 📺</summary>
    public static string Channel(int number)
    {
        var show = Shows[Math.Abs(number) % Shows.Length];
        var tag = show == "Hey Arnold!"
            ? "  ← the one that started everything."
            : "";
        return $"📺 Channel {number} → {show}{tag}";
    }

    /// <summary>
    /// Helga's mood meter. Sassy on the outside; a shrine to Arnold on the inside.
    /// The higher the sass, the deeper the secret. Tsundere calibration, Hey Arnold edition.
    /// </summary>
    public static string HelgaMood(int sass)
    {
        sass = Math.Clamp(sass, 0, 10);
        var outside = sass switch
        {
            0     => "Suspiciously sweet. 'Are you feeling okay, Arnold?'",
            <= 3  => "Mild eye-roll. A 'whatever, football head' under her breath.",
            <= 6  => "Classic Helga: 'MOVE IT, football head!' — then heart-eyes the second you turn around.",
            <= 8  => "Full sass. Somewhere a notebook of poems gets one page longer.",
            _     => "Maximum Helga. There's a shrine in the closet and your photo is on it."
        };
        return $"Sass level {sass}/10.\nOutside: {outside}\nInside: still, and always, crazy about {Arnold}. 💗";
    }

    /// <summary>
    /// The design & animation desk. Frames in, render time out,
    /// plus the layer count only a real designer would carry.
    /// </summary>
    public static (int RenderSeconds, int Layers, string Note) Render(int frames)
    {
        frames = Math.Max(0, frames);
        var seconds = frames * 3;               // ~3s a frame when the deadline is close
        var layers = 12 + frames % 47;          // it's always more layers than you'd think
        var note = frames switch
        {
            0     => "Nothing to render. Rare. She's probably sketching.",
            < 24  => "Under a second of animation. She'll redo it four times anyway.",
            < 240 => "A tidy little loop. Ship it.",
            _     => "A real render. The bar hits 99%, pauses dramatically, then finishes at 3 AM."
        };
        return (seconds, layers, note);
    }

    private static readonly string[] Memories =
    {
        "After school on Konyakina street, you'd sprint home so as not to miss Nickelodeon.",
        "The corner shop on Konyakina always had the good gum and a rented-out console.",
        "Summer on Konyakina: bikes, scraped knees, and the Rugrats theme through an open window.",
        "First snow on Konyakina, and cartoons until the screen was the only light in the room.",
        "You didn't know it yet, but somewhere out there a girl named Helga was rolling her eyes at Arnold too."
    };

    public static string Memory(int seed) => "🏠 " + Memories[Math.Abs(seed) % Memories.Length];

    private static readonly string[] Events =
    {
        "Helga is at Skhema in Kyiv. Expect a 'miss you, football head' text at 4 AM. 💌",
        "A design deadline and a rave on the same weekend. Somehow she nails both.",
        "SpongeBob marathon. Helga pretends she's too cool. She knows every line.",
        "Povitrya, Odessa: sea, bass, and a sunrise she'll turn into a loop by Monday.",
        "She redraws your logo for the third time. It's perfect now. ...And now again.",
        "Hey Arnold! rerun comes on. Helga goes quiet. That's the one.",
        "New colour palette pinned above the desk. The whole flat is now that shade of teal.",
        "3 AM, headphones on, tablet pen flying. Do not disturb the animator."
    };

    public static string RandomEvent() => Events[Rng.Next(Events.Length)];

    /// <summary>Pick a rave: 1 = Skhema/Kyiv, 2 = Povitrya/Odessa, anything else = surprise.</summary>
    public static RaveTrip PlanTrip(int choice, int nights) => choice switch
    {
        1 => new RaveTrip("Skhema", "Kyiv", Math.Max(1, nights)),
        2 => new RaveTrip("Povitrya", "Odessa", Math.Max(1, nights)),
        _ => Rng.Next(2) == 0
            ? new RaveTrip("Skhema", "Kyiv", Math.Max(1, nights))
            : new RaveTrip("Povitrya", "Odessa", Math.Max(1, nights))
    };
}
