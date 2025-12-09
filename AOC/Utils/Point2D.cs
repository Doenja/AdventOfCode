using System.Diagnostics.CodeAnalysis;

public struct Point2D
{
    public int X;
    public int Y;
    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    public double Length => Math.Sqrt(X * X + Y * Y);
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is Point2D p && p.X == X && p.Y == Y;
    }
    public static bool operator ==(Point2D a, Point2D b) => a.Equals(b);
    public static bool operator !=(Point2D a, Point2D b) => !a.Equals(b);

    public Point2D Add(Point2D p)
    {
        return new Point2D(X + p.X, Y + p.Y);
    }
    public static Point2D operator +(Point2D a, Point2D b) => a.Add(b);

    public Point2D Subtract(Point2D p)
    {
        return new Point2D(X - p.X, Y - p.Y);
    }
    public static Point2D operator -(Point2D a, Point2D b) => a.Subtract(b);
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
    public override string ToString() => $"({X}, {Y})";
}