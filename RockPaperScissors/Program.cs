using RockPaperScissors.Enums;

namespace RockPaperScissors;

class Program
{
    public static void Main()
    {
        var random
            = new Random();

        Move? previousUserMove = null;
        
        var gameStats
            = new GameStats();

        while (true)
        {
            Console.Clear();

            Console.WriteLine(
                "Welcome to Rock Paper Scissors!");

            gameStats
                .PrintStats();

            string? opponent = null;

            if (previousUserMove is not null)
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Choose your opponent: ");

                Console.WriteLine(
                    "[1] RANDOM BOT | [2] COPY BOT");

                opponent
                    = Console.ReadLine();
            }

            var isCopyBot
                = opponent == "2";
            
            Console.WriteLine();
            Console.WriteLine(
                "Choose your game mode: ");

            Console.WriteLine(
                "[1] CLASSIC | [2] BIG BANG THEORY");

            Enum.TryParse(
                Console.ReadLine(),
                out GameMode gameMode);

            Console.WriteLine();
            Console.WriteLine(
                "Enter your move: ");

            if (gameMode == GameMode.BigBangTheory)
            {
                Console.WriteLine(
                    "[1] ROCK | [2] PAPER | [3] SCISSORS | [4] LIZARD | [5] SPOCK");
            }
            else
            {
                Console.WriteLine(
                    "[1] ROCK | [2] PAPER | [3] SCISSORS");
            }

            var input
                = Console.ReadLine();

            var maxMove
                = gameMode == GameMode.BigBangTheory ? 5 : 3;

            if (!int.TryParse(input, out int moveInt) || moveInt < 1 || moveInt > maxMove)
                continue;

            var userMove
                = (Move)moveInt;

            Move computerMove;

            if (isCopyBot)
            {
                computerMove
                    = previousUserMove ?? userMove;
            }
            else
            {
                if (gameMode == GameMode.BigBangTheory)
                {
                    computerMove
                        = (Move)random.Next(1, 6);
                }
                else
                {
                    computerMove
                        = (Move)random.Next(1, 4);
                }
            }

            var outcome
                = GameRules.GetResult(
                    userMove,
                    computerMove);

            Console.WriteLine();
            Console.WriteLine(
                $"You played {userMove}");

            Console.WriteLine();
            Console.WriteLine(
                "Your opponent is thinking...");

            Thread.Sleep(
                1000);

            Console.WriteLine(
                $"Your opponent played {computerMove}");

            Console.WriteLine();
            switch (outcome)
            {
                case Outcome.Win:
                    Console.WriteLine(
                        "You win!");
                    break;
                case Outcome.Loss:
                    Console.WriteLine(
                        "You lose!");
                    break;
                case Outcome.Draw:
                    Console.WriteLine(
                        "It's a draw!");
                    break;
            }

            previousUserMove
                = userMove;

            gameStats
                .Update(
                    outcome);

            Console.WriteLine();
            Console.WriteLine(
                "Play Again? (y/n)");

            if (Console.ReadLine()?.Trim().ToLower() is not "y")
                break;
        }
    }
}