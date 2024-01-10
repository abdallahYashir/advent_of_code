using System.Text.RegularExpressions;

public class PuzzleTwo
{
    public Game[] Games { get; set; }

    public PuzzleTwo(string[] games)
    {
        Games = MapGames(games);
        // Print();
    }

    public Game[] MapGames(string[] games)
    {
        return games.Select(gameString =>
        {
            var split = gameString.Split(":");
            var id = int.Parse(split[0].Split(" ").Last());
            var rounds = split[1].Split(";");

            var colors = rounds.SelectMany(round => round.Split(","))
                               .Select(color => new
                               {
                                   Color = color.Contains("blue") ? "blue" :
                                           color.Contains("red") ? "red" :
                                           color.Contains("green") ? "green" : "",
                                   Number = int.Parse(Regex.Match(color, @"\d+").Value)
                               });

            var blue = colors.Where(c => c.Color == "blue").Sum(c => c.Number);
            var red = colors.Where(c => c.Color == "red").Sum(c => c.Number);
            var green = colors.Where(c => c.Color == "green").Sum(c => c.Number);

            return new Game(id, blue, red, green);
        }).ToArray();
    }

    public Game[] FilterByGame(int blue, int red, int green)
    {
        return Games.Where(game => game.Contains(blue, red, green)).ToArray();
    }

    public int DetermineSum(int blue, int red, int green)
    {
        var games = FilterByGame(blue, red, green);
        Print(games);
        return games.Sum(game => game.Id);
    }

    public int CalculateSum(string[] games)
    {
        int sum = 0;
        foreach (var line in games)
        {
            var game = line.Split(":");
            var moves = game[1].Split(";");
            var gameId = int.Parse(game[0].Split(" ").Last());
            var blue = 0;
            var red = 0;
            var green = 0;
            foreach (var move in moves)
            {
                var pieces = move.Trim().Split(",");
                foreach (var piece in pieces)
                {
                    int count = int.Parse(Regex.Match(piece, @"\d+").Value);
                    var color = piece.Trim().Split(" ").Last();
                    if (color == "red" && count > red)
                    {
                        red = count;
                    }
                    else if (color == "blue" && count > blue)
                    {
                        blue = count;
                    }
                    else if (color == "green" && count > green)
                    {
                        green = count;
                    }
                }
            }
            if (green <= 13 && blue <= 14 && red <= 12)
            {
                sum += gameId;
            }
        }
        return sum;
    }

    public void Print()
    {
        if (Games == null)
        {
            Console.WriteLine("Games is null");
            return;
        }
        foreach (var game in Games)
        {
            Console.WriteLine($"Id: {game.Id}, Blue: {game.Blue}, Red: {game.Red}, Green: {game.Green}");
        }
    }

    public void Print(Game[] games)
    {
        foreach (var game in games)
        {
            Console.WriteLine($"Id: {game.Id}, Blue: {game.Blue}, Red: {game.Red}, Green: {game.Green}");
        }
    }

}
