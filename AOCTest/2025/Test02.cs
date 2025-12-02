using System.Reflection;
using AdventOfCodeSupport;
using AdventOfCodeSupport.Testing;
using AOC._2025;

namespace AOC._2025;
public class Test02
{
    private readonly AdventSolutions _solutions;

    public Test02()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
    }

    [Fact]
    public void Part01()
    {
        var day = _solutions.GetDay(2025, 2);
        day.SetTestInput("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124");
        Assert.Equal("1227775554", day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        var day = _solutions.GetDay(2025, 2);
        day.SetTestInput("11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124");
        Assert.Equal("4174379265", day.Part2Answer);
    }

    [Fact]
    public static void TestGenerateNumberPart()
    {
        Assert.Equal(10000, Day02.GenerateNumberPart(5));
        Assert.Equal(1, Day02.GenerateNumberPart(1));
        Assert.Equal(10, Day02.GenerateNumberPart(2));
    }

    [Fact]
    public static void TestRepeatSequence()
    {
        var output = Day02.MakeRepeatedSequence(12534, 2);
        Assert.Equal(1253412534, output);

        var output2 = Day02.MakeRepeatedSequence(32, 3);
        Assert.Equal(323232, output2);

        var output3 = Day02.MakeRepeatedSequence(7, 12);
        Assert.Equal(777777777777, output3);
    }

    [Fact]
    public static void TestGetDivisors()
    {
        Assert.Equal(new List<int>{ 1, 2, 3, 6 }, Day02.GetDivisors(6));
        Assert.Equal(new List<int> { 1, 7 }, Day02.GetDivisors(7));
    }
}