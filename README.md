# dotnet-konyakina-nickelodeon 💛

A little TV set from **Konyakina street**, still tuned to Nickelodeon — now
co-run by **Helga Pawlowska**: sassy on the outside, a shrine to Arnold on the
inside. She designs, she animates, and she loves a good rave.

> For Olga. (Helga is from *Hey Arnold!* — all attitude, all heart.)

A tiny C# console app that does nothing serious: you type in a few numbers and
it hands back childhood cartoons, a mood reading, or a weekend in Kyiv or Odessa.

## Run it

```bash
dotnet run --project src/KonyakinaNick
```

## Guide

| Channel | What it does                                                    |
|:-------:|-----------------------------------------------------------------|
| 1       | Flip to a random Nickelodeon show                               |
| 2       | Helga's mood meter (sass outside, Arnold inside)                |
| 3       | Plan a rave — Skhema (Kyiv) or Povitrya (Odessa)                |
| 4       | The design & animation desk — frames, render time, layers      |
| 5       | A Konyakina street memory                                       |
| 6       | A random event                                                  |
| 0       | Exit                                                            |

## Layout

```
src/KonyakinaNick/
  Program.cs    — the TV guide menu
  Studio.cs     — shows, moods, memories, events
  RaveTrip.cs   — a weekend at Skhema or Povitrya
```

---

*Built for fun, as a tribute to the best girl on the street.* 💗
