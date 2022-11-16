// See https://aka.ms/new-console-template for more information

using TennisGame;

Console.WriteLine("Hello, World!");

TennisScoring tennisScoring = new TennisScoring();

string input = null;
while (input != "q") 
{
    input = Console.ReadLine();
    Console.WriteLine($"Value of input is {input}");
    if (input == "p1")
    {
        tennisScoring.PlayerOneScoresPoint();
    } 

    if (input == "p2")
    {
        tennisScoring.PlayerTwoScoresPoint();
    }

    string score = tennisScoring.GetScores(); 
    Console.WriteLine(score);
    if (score.StartsWith("Game"))
    {
        break;
    }
}