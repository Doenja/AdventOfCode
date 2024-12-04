using System.Reflection;
using AdventOfCodeSupport;
using AdventOfCodeSupport.Testing;

namespace AOC._2024;
public class Test02
{
    private readonly AdventSolutions _solutions;

    public Test02()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
    }

    [Fact]
    public void Part01()
    {
        var day = _solutions.GetDay(2024, 2);
        day.SetTestInput("7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9");
        Assert.Equal("2", day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        var day = _solutions.GetDay(2024, 2);
        day.SetTestInput("7 6 4 2 1\r\n1 2 7 8 9\r\n9 7 6 2 1\r\n1 3 2 4 5\r\n8 6 4 4 1\r\n1 3 6 7 9");
        Assert.Equal("4", day.Part2Answer);
    }
}