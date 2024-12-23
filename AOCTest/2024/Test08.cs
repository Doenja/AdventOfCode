using System.Reflection;
using AdventOfCodeSupport;

namespace AOC._2024;
public class Test08
{
    private readonly AdventSolutions _solutions;
    private readonly AdventBase _day;

    public Test08()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
        _day = _solutions.GetDay(2024, 8);
    }

    [Fact]
    public void Part01()
    {
        _day.SetTestInput("............\r\n........0...\r\n.....0......\r\n.......0....\r\n....0.......\r\n......A.....\r\n............\r\n............\r\n........A...\r\n.........A..\r\n............\r\n............");
        Assert.Equal("14", _day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        _day.SetTestInput("............\r\n........0...\r\n.....0......\r\n.......0....\r\n....0.......\r\n......A.....\r\n............\r\n............\r\n........A...\r\n.........A..\r\n............\r\n............");
        Assert.Equal("34", _day.Part2Answer);
    }

}