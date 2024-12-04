using AOC._2024;
using AdventOfCodeSupport;

internal class Program
{
    private static void Main(string[] args)
    {
        var solutions = new AdventSolutions();
        //var today = solutions.GetMostRecentDay();
        var today = new Day03();
        Console.WriteLine(today.ToString());

        PrintDivider();
        today.Part1();
        PrintDivider();
        today.Part2();
        PrintDivider();
    }

    public static void PrintDivider()
    {
        Console.WriteLine("-------------");
    }
}