using System.Diagnostics.CodeAnalysis;

public struct Point3D
{
    public int X;
    public int Y;
    public int Z;
    public Point3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is Point3D p && p.X == X && p.Y == Y && p.Z == Z;
    }
    public static bool operator ==(Point3D a, Point3D b) => a.Equals(b);
    public static bool operator !=(Point3D a, Point3D b) => !a.Equals(b);
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }
    public override string ToString() => $"({X}, {Y}, {Z})";
}