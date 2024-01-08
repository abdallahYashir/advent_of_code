using System.Text.RegularExpressions;

public class PuzzleTwo
{
    public Game[] Games { get; set; }

    public PuzzleTwo(string[] games)
    {
        Games = MapGames(games);
    }

    public Game[] MapGames(string[] games)
    {
        return games.Select(gameString =>
        {
            // first split by colon
            var split = gameString.Split(":");
            // this split by empty space and take the last element
            var id = split[0].Split(" ").Last();
            var rounds = split[1].Split(";").ToArray();
            // iterate rounds and split by comma

            var roundsSplit = rounds.Select(round => round.Split(",")).ToArray();

            var blue = 0;
            var red = 0;
            var green = 0;


            // iterate and check if string contains B, R, or G
            // if so, increment the color

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

            Console.WriteLine($"Id: {id}, Blue: {blue}, Red: {red}, Green: {green}");

            return new Game
            {
                Id = int.Parse(id),
                Blue = 1,
                Red = 1,
                Green = 1
            };
        }).ToArray();
    }

    public void StructureGames()
    {
        foreach(var game in Games)
        {
            Console.WriteLine(game);
        }
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

    public class Game
    {
        public int Id { get; set; }
        public int Blue { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
    }
}
