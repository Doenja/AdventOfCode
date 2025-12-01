using System.Reflection;
using AdventOfCodeSupport;
using AdventOfCodeSupport.Testing;
using AOC._2025;

namespace AOC._2025;
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
        var day = _solutions.GetDay(2025, 1);
        day.SetTestInput("L68\r\nL30\r\nR48\r\nL5\r\nR60\r\nL55\r\nL1\r\nL99\r\nR14\r\nL82");
        Assert.Equal("3", day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        var day = _solutions.GetDay(2025, 1);
        day.SetTestInput("L68\r\nL30\r\nR48\r\nL5\r\nR60\r\nL55\r\nL1\r\nL99\r\nR14\r\nL82");
        Assert.Equal("6", day.Part2Answer);
    }

    [Fact]
    public void TestCounterRight()
    {
        Assert.Equal(0, Day01.CountZeroLandOrPass(30, 40));
        Assert.Equal(1, Day01.CountZeroLandOrPass(30, 110));
        Assert.Equal(0, Day01.CountZeroLandOrPass(-30, -2));
        Assert.Equal(2, Day01.CountZeroLandOrPass(-30, 110));
        Assert.Equal(2, Day01.CountZeroLandOrPass(0, 250));
        Assert.Equal(1, Day01.CountZeroLandOrPass(-30, 0));
        Assert.Equal(4, Day01.CountZeroLandOrPass(-120, 200));
        Assert.Equal(4, Day01.CountZeroLandOrPass(-120, 270));
        Assert.Equal(1, Day01.CountZeroLandOrPass(0, 100));
    }

    [Fact]
    public void TestCounterLeft()
    {
        Assert.Equal(0, Day01.CountZeroLandOrPass(50, 30));
        Assert.Equal(1, Day01.CountZeroLandOrPass(50, -20));
        Assert.Equal(0, Day01.CountZeroLandOrPass(-30, -42));
        Assert.Equal(0, Day01.CountZeroLandOrPass(0, -50));
        Assert.Equal(1, Day01.CountZeroLandOrPass(50, 0));
        Assert.Equal(2, Day01.CountZeroLandOrPass(100, -100));
        Assert.Equal(5, Day01.CountZeroLandOrPass(150, -320));
    }
}