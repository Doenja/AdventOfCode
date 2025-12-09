using AdventOfCodeSupport;
using System.Reflection;

namespace AOC._2025;

public class Test03
{
    private readonly AdventSolutions _solutions;

    public Test03()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
    }

    [Fact]
    public void Part01()
    {
        var day = _solutions.GetDay(2025, 3);
        day.SetTestInput("987654321111111\r\n811111111111119\r\n234234234234278\r\n818181911112111\r\n");
        Assert.Equal("357", day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        var day = _solutions.GetDay(2025, 3);
        day.SetTestInput("987654321111111\r\n811111111111119\r\n234234234234278\r\n818181911112111\r\n");
        Assert.Equal("3121910778619", day.Part2Answer);
    }


}