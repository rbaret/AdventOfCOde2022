using System;


namespace Utility;

public class Maths
{
    public double DistanceBetweenPoints(double xa, double ya, double xb, double yb)
    {
        return Math.Sqrt(Math.Pow(xb-xa,2)+Math.Pow(yb-ya,2));
    }

}
