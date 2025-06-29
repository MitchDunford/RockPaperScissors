using RockPaperScissors.Enums;

namespace RockPaperScissors;

public static class GameRules
{
    public static Outcome GetResult(
        Move player,
        Move computer)
    {
        if (player == computer)
            return Outcome.Draw;

        return (player, computer) switch
        {
            (Move.Rock, Move.Scissors) => Outcome.Win,
            (Move.Rock, Move.Lizard) => Outcome.Win,
            (Move.Paper, Move.Rock) => Outcome.Win,
            (Move.Paper, Move.Spock) => Outcome.Win,
            (Move.Scissors, Move.Paper) => Outcome.Win,
            (Move.Scissors, Move.Lizard) => Outcome.Win,
            (Move.Lizard, Move.Spock) => Outcome.Win,
            (Move.Lizard, Move.Paper) => Outcome.Win,
            (Move.Spock, Move.Scissors) => Outcome.Win,
            (Move.Spock, Move.Rock) => Outcome.Win,
            _ => Outcome.Loss
        };
    }
}