using AdventOfCodeSupport;
using System.Reflection;

namespace AOC._2025;

public class Test08
{
    private readonly AdventSolutions _solutions;

    public Test08()
    {
        Assembly.Load("AOC");
        _solutions = new AdventSolutions();
    }

    [Fact]
    public void Part01()
    {
        var day = _solutions.GetDay(2025, 8);
        day.SetTestInput("162,817,812\r\n57,618,57\r\n906,360,560\r\n592,479,940\r\n352,342,300\r\n466,668,158\r\n542,29,236\r\n431,825,988\r\n739,650,466\r\n52,470,668\r\n216,146,977\r\n819,987,18\r\n117,168,530\r\n805,96,715\r\n346,949,466\r\n970,615,88\r\n941,993,340\r\n862,61,35\r\n984,92,344\r\n425,690,689");
        Assert.Equal("40", day.Part1Answer);
    }

    [Fact]
    public void Part02()
    {
        var day = _solutions.GetDay(2025, 8);
        day.SetTestInput("162,817,812\r\n57,618,57\r\n906,360,560\r\n592,479,940\r\n352,342,300\r\n466,668,158\r\n542,29,236\r\n431,825,988\r\n739,650,466\r\n52,470,668\r\n216,146,977\r\n819,987,18\r\n117,168,530\r\n805,96,715\r\n346,949,466\r\n970,615,88\r\n941,993,340\r\n862,61,35\r\n984,92,344\r\n425,690,689");
        Assert.Equal("25272", day.Part2Answer);
    }

    [Fact]
    public void EuclideanDistance()
    {
        var day08 = new Day08();
        var result = day08.EuclideanDistance(new Point3D(1, 2, 3), new Point3D(4, 6, 8));
        Assert.Equal(7.07, result, precision: 3);
    }


}