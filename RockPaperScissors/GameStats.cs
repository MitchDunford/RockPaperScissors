using RockPaperScissors.Enums;

namespace RockPaperScissors;

public class GameStats
{
    public int Wins { get; private set; }
    public int Losses { get; private set; }
    public int Draws { get; private set; }

    public int GameCount => Wins + Losses + Draws;

    public void Update(
        Outcome outcome)
    {
        switch (outcome)
        {
            case Outcome.Win:
                Wins++;
                break;
            case Outcome.Loss:
                Losses++;
                break;
            case Outcome.Draw:
                Draws++;
                break;
        }
    }

    public void PrintStats()
    {
        Console.WriteLine();
        Console.WriteLine("Stats");
        Console.WriteLine($"Wins: {Wins}");
        Console.WriteLine($"Losses: {Losses}");
        Console.WriteLine($"Draws: {Draws}");
        Console.WriteLine($"Total: {GameCount}");
    }
}