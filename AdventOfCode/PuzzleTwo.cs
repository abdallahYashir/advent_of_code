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

    public (int, int) CalculateSum(string[] games)
    {
        int sum = 0;
        int powerSum = 0;
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
            int power = red * blue * green;
            powerSum += power;
        }
        return (sum, powerSum);
    }

    public (int, int) Aggregate(string[] games)
    {
        var results = games.Select(gameLine =>
        {
            var gameParts = gameLine.Split(":");
            var gameId = int.Parse(gameParts[0].Split(" ").Last());
            var moves = gameParts[1].Split(";");

            var colors = moves.SelectMany(move => move.Trim().Split(","))
                            .Select(piece =>
                            {
                                var count = int.Parse(Regex.Match(piece, @"\d+").Value);
                                var color = piece.Trim().Split(" ").Last();
                                return new { Color = color, Count = count };
                            });

            var maxRed = colors.Where(c => c.Color == "red").Max(c => c.Count);
            var maxBlue = colors.Where(c => c.Color == "blue").Max(c => c.Count);
            var maxGreen = colors.Where(c => c.Color == "green").Max(c => c.Count);

            return new
            {
                GameId = gameId,
                MaxRed = maxRed,
                MaxBlue = maxBlue,
                MaxGreen = maxGreen,
                Power = maxRed * maxBlue * maxGreen
            };
        });

        var sum = results.Where(r => r.MaxGreen <= 13 && r.MaxBlue <= 14 && r.MaxRed <= 12)
                        .Sum(r => r.GameId);

        var powerSum = results.Sum(r => r.Power);

        return (sum, powerSum);
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
