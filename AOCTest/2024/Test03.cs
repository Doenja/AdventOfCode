using System.Reflection;
using AdventOfCodeSupport;

namespace AOC._2024;
public class Test03
{
    private readonly AdventSolutions _solutions;
    private readonly AdventBase _day;

    public Test03()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
        _day = _solutions.GetDay(2024, 3);
    }

    [Fact]
    public void Part01()
    {
        _day.SetTestInput("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))");
        Assert.Equal("161", _day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        _day.SetTestInput("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))");
        Assert.Equal("48", _day.Part2Answer);
    }
}