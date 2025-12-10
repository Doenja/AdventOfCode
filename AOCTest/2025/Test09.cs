using AdventOfCodeSupport;
using System.Reflection;

namespace AOC._2025;

public class Test09
{
    private readonly AdventSolutions _solutions;

    public Test09()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
    }

    [Fact]
    public void Part01()
    {
        var day = _solutions.GetDay(2025, 9);
        day.SetTestInput("7,1\r\n11,1\r\n11,7\r\n9,7\r\n9,5\r\n2,5\r\n2,3\r\n7,3");
        Assert.Equal("50", day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        var day = _solutions.GetDay(2025, 9);
        day.SetTestInput("7,1\r\n11,1\r\n11,7\r\n9,7\r\n9,5\r\n2,5\r\n2,3\r\n7,3");
        Assert.Equal("24", day.Part2Answer);
    }
}