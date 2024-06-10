RockPaperScissrs game = new();

while (true)
{
    game.DisplayMenu();
}
public class RockPaperScissrs
{
    Player player1 = new("Player 1");
    Player player2 = new("Player 2");

    public void DisplayMenu()
    {
        Console.Clear();
            Console.WriteLine("""
                Please choose from the following:
                1. Play Rock, Paper, Scissors
                2. View previous scores
                3. Statistics

                """);
        int input = Convert.ToInt32(UserInput("Input: "));

        if (input == 1) RunGame();
        if (input == 2) DisplayScores();
        if (input == 3) DisplayStats();
    }
    private void RunGame()
    {
        Console.Clear();
        player1.Attack = Attack(UserInput("Player 1. Choose your fate: rock, paper, or scissors: "), player1);
        Console.Clear();
        player2.Attack = Attack(UserInput("Player 2. Choose your fate: rock, paper, or scissors: "), player2);

        Console.WriteLine($"Player 1 chose {player1.Attack}");
        Console.WriteLine($"Player 2 chose {player2.Attack}");

        if (HasWon(player1.Attack, player2.Attack))
        {
            Console.WriteLine("Play 1 has Won!");
            player1.Wins++;
            player2.Loses++;
        }
        else if (HasWon(player2.Attack, player1.Attack))
        {
            Console.WriteLine("Play 2 has Won!");
            player2.Wins++;
            player1.Loses++;
        }
        else
        {
            Console.WriteLine("Draw. Play again.");
            player1.Draws++;
            player2.Draws++;
        }
        Console.Write("Please press any key to continue.");
        Console.ReadKey();
    }
    private void DisplayScores()
    {
        Console.Clear();
        Console.WriteLine($"{player1.PlayerNumber} has won {player1.Wins}, lost {player1.Loses}, and drawn {player1.Draws}.");
        Console.WriteLine($"{player2.PlayerNumber} has won {player2.Wins}, lost {player2.Loses}, and drawn {player2.Draws}.");
        Console.Write("Please press any key to continue.");
        Console.ReadKey();
    }

    private void DisplayStats()
    {
        Console.Clear();
        Console.WriteLine($"{player1.PlayerNumber} has chose Rock {player1.Rock} times, Paper {player1.Paper} times, and Scissors {player1.Scissors} times.");
        Console.WriteLine($"{player2.PlayerNumber} has chose Rock {player2.Rock} times, Paper {player2.Paper} times, and Scissors {player2.Scissors} times");
        Console.Write("Please press any key to continue.");
        Console.ReadKey();
    }

    private string UserInput(string text)
    {
        Console.Write(text);
        string? input = String.Empty;
        while (String.IsNullOrEmpty(input))
        {
            input = Console.ReadLine();
        }
        return input;
    }

    private RPS Attack(string input, Player player)
    {
        RPS attackValue = new();
        bool validResponse = false;

        do
        {
            switch (input)
            {
                case "rock":
                    attackValue = RPS.Rock;
                    validResponse = true;
                    player.Rock++;
                    break;
                case "paper":
                    attackValue = RPS.Paper;
                    validResponse = true;
                    player.Rock++;
                    break;
                case "scissors":
                    attackValue = RPS.Scissors;
                    validResponse = true;
                    player.Scissors++;
                    break;
                default:
                    Console.Write("Invalid response. Please eneter only rock, paper, or scisssors: ");
                    input = Console.ReadLine();
                    break;
            };
        } while (!validResponse);

        return attackValue;
    }

    private bool HasWon(RPS player1, RPS player2)
    {
        if ((RPS.Rock == player1) && (RPS.Scissors == player2)) return true;
        if ((RPS.Paper == player1) && (RPS.Rock == player2)) return true;
        if ((RPS.Scissors == player1) && (RPS.Paper == player2)) return true;

        //Draw
        return false;
    }
}
public class Player
{
    public readonly string PlayerNumber;
    public RPS Attack { get; set; }
    public int Wins { get; set; }
    public int Loses { get; set; }
    public int Draws { get; set; }
    public int Rock { get; set; }
    public int Paper { get; set; }
    public int Scissors { get; set; }


    public Player(string playerNumber)
    {
        PlayerNumber = playerNumber;
    }
}
public enum RPS { Rock, Paper, Scissors }