using RockPaperScissors.Enums;

namespace RockPaperScissors;

class Program
{
    public static void Main()
    {
        var random
            = new Random();

        Move? previousUserMove = null;

        while (true)
        {
            Console.Clear();

            Console.WriteLine(
                "Welcome to Rock Paper Scissors!");

            string? opponent = null;

            if (previousUserMove is not null)
            {
                Console.WriteLine(
                    "Choose your opponent: ");

                Console.WriteLine(
                    "[1] RANDOM BOT | [2] COPY BOT");

                opponent
                    = Console.ReadLine();
            }           

            var isCopyBot
                = opponent == "2";

            Console.WriteLine(
                "[1] ROCK | [2] PAPER | [3] SCISSORS");

            Console.WriteLine(
                "Enter your move: ");

            var input
                = Console.ReadLine();

            if (!int.TryParse(input, out int moveInt) || moveInt < 1 || moveInt > 3)
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
                computerMove
                    = (Move)random.Next(1, 4);
            }

            var outcome
                = GameRules.GetResult(
                    userMove,
                    computerMove);

            Console.WriteLine(
                $"You played {userMove}");

            Console.WriteLine(
                "Your opponent is thinking...");

            Thread.Sleep(
                1000);

            Console.WriteLine(
                $"Your opponent played {computerMove}");

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

            Console.WriteLine(
                "Play Again? (y/n)");

            if (Console.ReadLine()?.Trim().ToLower() is not "y")
                break;
        }
    }
}