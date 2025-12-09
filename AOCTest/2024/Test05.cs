using AdventOfCodeSupport;
using System.Reflection;

namespace AOC._2024;

public class Test05
{
    private readonly AdventSolutions _solutions;
    private readonly AdventBase _day;

    public Test05()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
        _day = _solutions.GetDay(2024, 5);
    }

    [Fact]
    public void Part01()
    {
        _day.SetTestInput("47|53\r\n97|13\r\n97|61\r\n97|47\r\n75|29\r\n61|13\r\n75|53\r\n29|13\r\n97|29\r\n53|29\r\n61|53\r\n97|53\r\n61|29\r\n47|13\r\n75|47\r\n97|75\r\n47|61\r\n75|61\r\n47|29\r\n75|13\r\n53|13\r\n\r\n75,47,61,53,29\r\n97,61,53,29,13\r\n75,29,13\r\n75,97,47,61,53\r\n61,13,29\r\n97,13,75,29,47");
        Assert.Equal("143", _day.Part1Answer);
    }

}