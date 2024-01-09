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
        List<Game> gameList = new();

        foreach (var gameString in games)
        {
            var split = gameString.Split(":");
            var id = split[0].Split(" ").Last();
            var rounds = split[1].Split(";").ToArray();

            var roundsSplit = rounds.Select(round => round.Split(",")).ToArray();

            var blue = 0;
            var red = 0;
            var green = 0;

            foreach (var roundValue in roundsSplit)
            {
                foreach (var color in roundValue)
                {
                    var number = 0;
                    if (color.Contains("blue"))
                    {
                        var match = Regex.Match(color, @"\d+");
                        if (match.Success)
                        {
                            number = int.Parse(match.Value);
                            blue += Convert.ToInt32(number);
                        }
                    }
                    else if (color.Contains("red"))
                    {
                        var match = Regex.Match(color, @"\d+");
                        if (match.Success)
                        {
                            number = int.Parse(match.Value);
                            red += Convert.ToInt32(number);
                        }
                    }
                    else if (color.Contains("green"))
                    {
                        var match = Regex.Match(color, @"\d+");
                        if (match.Success)
                        {
                            number = int.Parse(match.Value);
                            green += Convert.ToInt32(number);
                        }
                    }
                }
            }

            Game game = new(int.Parse(id), blue, red, green);

            gameList.Add(game);
        }

        return [.. gameList];
    }

    public Game[] FilterByGame(int blue, int red, int green)
    {
        return Games.Where(game => game.Contains(blue, red, green)).ToArray();
    }

    public int DetermineSum(int blue, int red, int green)
    {
        var games = FilterByGame(blue, red, green);
        return games.Sum(game => game.Id);
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
