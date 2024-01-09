

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

var file = FileUtil.ReadFile("day2.txt");
var fullFile = FileUtil.ReadFile("day2_full.txt");
const int red = 12;
const int blue = 14;
const int green = 13;

PuzzleTwo puzzleTwo = new(file);
var sum = puzzleTwo.DetermineSum(blue, red, green);
Console.WriteLine($"Sum: {sum}");


PuzzleTwo puzzleTwoFull = new(fullFile);
var sumFull = puzzleTwoFull.DetermineSum(blue, red, green);
Console.WriteLine($"Sum: {sumFull}");