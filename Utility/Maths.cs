using System;


namespace Utility;

public class Maths
{
    public double DistanceBetweenPoints(double xa, double ya, double xb, double yb)
    {
        return Math.Sqrt(Math.Pow(xb-xa,2)+Math.Pow(yb-ya,2));
    }

    // Function to return LCM of two numbers
    public int lcm(int a, int b)
    {
        return Math.Abs(a * b) / gcd(a, b);
    }

    // Function to return GCD of two numbers
    public int gcd(int a, int b)
    {
        if (a == 0)
            return b;
        return gcd(b % a, a);
    }

}
