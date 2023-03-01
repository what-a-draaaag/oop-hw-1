using System.Numerics;
using System.Text.RegularExpressions;

namespace Task1;

public class Rational : IComparable<Rational>
{
    public int Numerator;
    public int Denominator;

    public Rational(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
        Normalize(ref Numerator, ref Denominator);
    }

    public Rational(int whole, int numerator, int denominator)
        : this(whole * denominator + numerator * (whole >= 0 ? 1 : -1), denominator)
    {
    }

    public Rational(Rational rational) : this(rational.Numerator, rational.Denominator)
    {
    }

    public static Rational operator +(Rational r1, Rational r2) =>
        new(r1.Numerator * r2.Denominator + r1.Denominator * r2.Numerator,
            r1.Denominator * r2.Denominator);

    public static Rational operator -(Rational r1, Rational r2) =>
        new(r1.Numerator * r2.Denominator - r1.Denominator * r2.Numerator,
            r1.Denominator * r2.Denominator);

    public static Rational operator *(Rational r1, Rational r2) =>
        new(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);

    public static Rational operator /(Rational r1, Rational r2) =>
        new(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);

    public static bool operator ==(Rational r1, Rational r2) => r1.CompareTo(r2) == 0;
    public static bool operator <=(Rational r1, Rational r2) => r1.CompareTo(r2) <= 0;
    public static bool operator >(Rational r1, Rational r2) => r1.CompareTo(r2) > 0;
    public static bool operator <(Rational r1, Rational r2) => r1.CompareTo(r2) < 0;
    public static Rational operator -(Rational r) => r * new Rational(-1, 1);
    public static bool operator !=(Rational r1, Rational r2) => r1.CompareTo(r2) != 0;
    public static bool operator >=(Rational r1, Rational r2) => r1.CompareTo(r2) >= 0;
    public static implicit operator Rational(int i) => new(i, 1);


    public Rational(string fraction)
    {
        var match = Regex.Match(fraction, @"^(?<numerator>-?\d+)(?:/(?<denominator>-?\d+))?$");
        Numerator = int.Parse(match.Groups["numerator"].Value);
        Denominator = 1;
        if (match.Groups["denominator"].Captures.Count > 0)
            Denominator = int.Parse(match.Groups["denominator"].Value);
        Normalize(ref Numerator, ref Denominator);
    }

    private static void Normalize(ref int a, ref int b)
    {
        var gcd = (int)BigInteger.GreatestCommonDivisor(new BigInteger(a), new BigInteger(b));
        a /= gcd;
        b /= gcd;
        if (b >= 0) return;
        a *= -1;
        b *= -1;
    }


    public int CompareTo(Rational? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var dif = this - other;
        return dif.Numerator.CompareTo(0);
    }

    public override string ToString() => Denominator switch
    {
        1 => $"{Numerator}",
        -1 => $"-{Numerator}",
        _ => $"{Numerator}/{Denominator}"
    };


    private bool Equals(Rational other) => GetHashCode() == other.GetHashCode();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == GetType() && Equals((Rational)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    public bool WholeNumber => Numerator % Denominator == 0;
    public bool Zero => Numerator == 0;
    public int WholePart => Numerator / Denominator;
    public Rational ProperPart => new(Math.Abs(Numerator % Denominator), Denominator);
}