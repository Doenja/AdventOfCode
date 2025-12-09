using AdventOfCodeSupport;
using System.Reflection;

namespace AOC._2024;

public class Test06
{
    private readonly AdventSolutions _solutions;
    private readonly AdventBase _day;

    public Test06()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
        _day = _solutions.GetDay(2024, 6);
    }

    [Fact]
    public void Part01()
    {
        _day.SetTestInput("....#.....\r\n.........#\r\n..........\r\n..#.......\r\n.......#..\r\n..........\r\n.#..^.....\r\n........#.\r\n#.........\r\n......#...");
        Assert.Equal("41", _day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        _day.SetTestInput("....#.....\r\n.........#\r\n..........\r\n..#.......\r\n.......#..\r\n..........\r\n.#..^.....\r\n........#.\r\n#.........\r\n......#...");
        Assert.Equal("6", _day.Part2Answer);
    }

}