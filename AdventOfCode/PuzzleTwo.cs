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
        foreach (var game in games)
        {
            var line = game.Replace(";", ",");
            var split = line.Split(":");
            var id = int.Parse(split[0].Split(" ").Last());
            var rounds = split[1].Split(",");

            var red = 0;
            var blue = 0;
            var green = 0;
            
            foreach (var round in rounds)
            {
                if (round.Contains("blue"))
                {
                    blue += int.Parse(Regex.Match(round, @"\d+").Value);
                }
                else if (round.Contains("red"))
                {
                    red += int.Parse(Regex.Match(round, @"\d+").Value);
                }
                else if (round.Contains("green"))
                {
                    green += int.Parse(Regex.Match(round, @"\d+").Value);
                }
            }


            if (blue <= 14 && red <= 12 && green <= 13)
            {
                sum += id;
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
