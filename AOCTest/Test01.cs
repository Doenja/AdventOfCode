using System.Reflection;
using AdventOfCodeSupport;
using AdventOfCodeSupport.Testing;

namespace AOC._2024;
public class Test01
{
    private readonly AdventSolutions _solutions;

    public Test01()
    {
        Assembly.Load("AOC"); // Use actual project name containing your solutions
        _solutions = new AdventSolutions();
    }

    [Fact]
    public void Part01()
    {
        var day = _solutions.GetDay(2024, 1);
        day.SetTestInput("");
        Assert.Equal("0", day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        var day = _solutions.GetDay(2024, 1);
        day.SetTestInput("");
        Assert.Equal("0", day.Part2Answer);
    }
}