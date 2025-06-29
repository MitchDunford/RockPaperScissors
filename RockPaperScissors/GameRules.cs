using RockPaperScissors.Enums;

namespace RockPaperScissors;

public static class GameRules
{
    public static Outcome GetResult(
        Move player,
        Move computer)
    {
        if (player == computer)
        {
            return Outcome.Draw;
        }

        if (player == Move.Rock && computer == Move.Scissors ||
            player == Move.Paper && computer == Move.Rock ||
            player == Move.Scissors && computer == Move.Paper)
        {
            return Outcome.Win;
        }

        return Outcome.Loss;
    }
}