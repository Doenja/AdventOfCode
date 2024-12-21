using System.Reflection;
using AdventOfCodeSupport;

namespace AOC._2024;
public class Test07
{
    private readonly AdventSolutions _solutions;
    private readonly AdventBase _day;

    public Test07()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
        _day = _solutions.GetDay(2024, 7);
    }

    [Fact]
    public void Part01()
    {
        _day.SetTestInput("190: 10 19\r\n3267: 81 40 27\r\n83: 17 5\r\n156: 15 6\r\n7290: 6 8 6 15\r\n161011: 16 10 13\r\n192: 17 8 14\r\n21037: 9 7 18 13\r\n292: 11 6 16 20");
        Assert.Equal("3749", _day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        _day.SetTestInput("190: 10 19\r\n3267: 81 40 27\r\n83: 17 5\r\n156: 15 6\r\n7290: 6 8 6 15\r\n161011: 16 10 13\r\n192: 17 8 14\r\n21037: 9 7 18 13\r\n292: 11 6 16 20");
        Assert.Equal("11387", _day.Part2Answer);
    }

}