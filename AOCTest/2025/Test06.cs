using System.Reflection;
using AdventOfCodeSupport;
using AdventOfCodeSupport.Testing;
using AOC._2025;

namespace AOC._2025;
public class Test06
{
    private readonly AdventSolutions _solutions;

    public Test06()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
    }

    [Fact]
    public void Part01()
    {
        var day = _solutions.GetDay(2025, 6);
        day.SetTestInput("123 328  51 64 \r\n 45 64  387 23 \r\n  6 98  215 314\r\n*   +   *   +");
        Assert.Equal("4277556", day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        var day = _solutions.GetDay(2025, 6);
        day.SetTestInput("123 328  51 64 \r\n 45 64  387 23 \r\n  6 98  215 314\r\n*   +   *   +");
        Assert.Equal("", day.Part2Answer);
    }

  
}