using Xunit;

public class PuzzleTwoTests
{
    [Fact]
    public void TestDetermineSum()
    {
        var file = FileUtil.ReadFile("day2.txt");
        const int red = 12;
        const int blue = 14;
        const int green = 13;

        PuzzleTwo puzzleTwo = new(file);
        var sum = puzzleTwo.DetermineSum(blue, red, green);
        Assert.Equal(8, sum);
    }
}