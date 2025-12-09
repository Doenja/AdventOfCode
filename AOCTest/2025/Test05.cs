using AdventOfCodeSupport;
using System.Reflection;

namespace AOC._2025;

public class Test05
{
    private readonly AdventSolutions _solutions;

    public Test05()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
    }

    [Fact]
    public void Part01()
    {
        var day = _solutions.GetDay(2025, 5);
        day.SetTestInput("3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32");
        Assert.Equal("3", day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        var day = _solutions.GetDay(2025, 5);
        day.SetTestInput("3-5\r\n10-14\r\n16-20\r\n12-18\r\n\r\n1\r\n5\r\n8\r\n11\r\n17\r\n32");
        Assert.Equal("14", day.Part2Answer);
    }


}