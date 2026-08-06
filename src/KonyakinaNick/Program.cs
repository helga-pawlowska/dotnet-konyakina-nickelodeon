using KonyakinaNick;

// =====================================================================
//  KONYAKINA NICKELODEON
//  A little TV set from Konyakina street, still tuned to Nickelodeon.
//  These days it's co-run by Helga — sassy on the outside, a shrine to
//  Arnold on the inside. She designs, she animates, she raves. For Olga. 💛
// =====================================================================

Console.OutputEncoding = System.Text.Encoding.UTF8;

Banner();

while (true)
{
    Menu();
    Console.Write("\n> Change the channel: ");
    var option = Console.ReadLine()?.Trim();

    Console.WriteLine();
    switch (option)
    {
        case "1": FlipChannel(); break;
        case "2": Mood(); break;
        case "3": RavePlanner(); break;
        case "4": DesignDesk(); break;
        case "5": StreetMemory(); break;
        case "6": Console.WriteLine("🎲 " + Studio.RandomEvent()); break;
        case "0" or "q" or "quit":
            Console.WriteLine("Bye, football head. 💛");
            return;
        default:
            Console.WriteLine("Static. Nothing on that channel. Try again.");
            break;
    }

    Console.WriteLine("\n(press enter to go back to the guide)");
    Console.ReadLine();
    ClearScreen();
    Banner();
}

// ---------------------------------------------------------------------
// UI
// ---------------------------------------------------------------------

static void Banner()
{
    const int w = 48;
    Console.WriteLine("╔" + new string('═', w) + "╗");
    Console.WriteLine(Center("K O N Y A K I N A   N I C K E L O D E O N", w));
    Console.WriteLine(Center("Helga Pawlowska · \"move it, football head\"", w));
    Console.WriteLine(Center("the street where it all started", w));
    Console.WriteLine("╚" + new string('═', w) + "╝");

    static string Center(string s, int width)
    {
        var pad = Math.Max(0, width - s.Length);
        var left = pad / 2;
        return "║" + new string(' ', left) + s + new string(' ', pad - left) + "║";
    }
}

static void Menu()
{
    Console.WriteLine();
    Console.WriteLine("  1) Flip to a Nickelodeon channel");
    Console.WriteLine("  2) Helga's mood meter");
    Console.WriteLine("  3) Plan a rave (Skhema / Povitrya)");
    Console.WriteLine("  4) The design & animation desk");
    Console.WriteLine("  5) A Konyakina street memory");
    Console.WriteLine("  6) Random event");
    Console.WriteLine("  0) Exit");
}

// ---------------------------------------------------------------------
// Channels
// ---------------------------------------------------------------------

static void FlipChannel()
{
    Console.WriteLine("— TV guide —");
    var number = (int)AskNumber("Pick a channel number: ");
    Console.WriteLine();
    Console.WriteLine(Studio.Channel(number));
}

static void Mood()
{
    Console.WriteLine("— Helga's mood meter —");
    var sass = (int)AskNumber("How sassy is she today? (0–10): ");
    Console.WriteLine();
    Console.WriteLine(Studio.HelgaMood(sass));
}

static void RavePlanner()
{
    Console.WriteLine("— Rave planner —");
    Console.WriteLine("  1) Skhema (Kyiv)   2) Povitrya (Odessa)   3) Surprise me");
    var choice = (int)AskNumber("Destination: ");
    var nights = (int)AskNumber("How many nights?: ");
    var trip = Studio.PlanTrip(choice, nights);
    Console.WriteLine();
    Console.WriteLine(trip.Summary());
}

static void DesignDesk()
{
    Console.WriteLine("— Design & animation desk —");
    var frames = (int)AskNumber("How many frames to render?: ");
    var (seconds, layers, note) = Studio.Render(frames);
    Console.WriteLine($"\nRender time: {seconds} s   ·   Layers: {layers}");
    Console.WriteLine(note);
}

static void StreetMemory()
{
    Console.WriteLine("— Konyakina street —");
    var seed = (int)AskNumber("Enter any number (a year, an age, anything): ");
    Console.WriteLine();
    Console.WriteLine(Studio.Memory(seed));
}

// ---------------------------------------------------------------------
// Helpers
// ---------------------------------------------------------------------

static void ClearScreen()
{
    // Console.Clear() blows up if output is redirected (no real terminal).
    try { Console.Clear(); } catch (IOException) { /* no console, keep going */ }
}

static double AskNumber(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        var text = Console.ReadLine();
        if (double.TryParse(text, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out var value))
            return value;
        Console.WriteLine("  Come on, type a number.");
    }
}
