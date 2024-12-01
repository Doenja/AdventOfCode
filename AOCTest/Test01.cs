using System.Reflection;
using AdventOfCodeSupport;
using AdventOfCodeSupport.Testing;

namespace AOC._2024;
public class Test01
{
    private readonly AdventSolutions _solutions;

    public Test01()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
    }

    [Fact]
    public void Part01()
    {
        var day = _solutions.GetDay(2024, 1);
        day.SetTestInput("3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3");
        Assert.Equal("11", day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        var day = _solutions.GetDay(2024, 1);
        day.SetTestInput("3   4\r\n4   3\r\n2   5\r\n1   3\r\n3   9\r\n3   3");
        Assert.Equal("31", day.Part2Answer);
    }
}