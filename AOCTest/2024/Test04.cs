using System.Reflection;
using AdventOfCodeSupport;

namespace AOC._2024;
public class Test04
{
    private readonly AdventSolutions _solutions;
    private readonly AdventBase _day;

    public Test04()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
        _day = _solutions.GetDay(2024, 4);
        _day.SetTestInput("");
    }

    [Fact]
    public void Part01()
    {
        Assert.Equal("", _day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        Assert.Equal("", _day.Part2Answer);
    }
}