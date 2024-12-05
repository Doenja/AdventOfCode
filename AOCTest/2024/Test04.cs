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
    }

    [Fact]
    public void Part01()
    {
        _day.SetTestInput("MMMSXXMASM\r\nMSAMXMSMSA\r\nAMXSXMAAMM\r\nMSAMASMSMX\r\nXMASAMXAMM\r\nXXAMMXXAMA\r\nSMSMSASXSS\r\nSAXAMASAAA\r\nMAMMMXMMMM\r\nMXMXAXMASX");
        Assert.Equal("18", _day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        _day.SetTestInput("");
        Assert.Equal("", _day.Part2Answer);
    }
}