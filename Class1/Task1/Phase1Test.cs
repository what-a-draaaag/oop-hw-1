using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Task1;

public class Phase1Test
{
    [Test]
    public void TestCanonicity()
    {
        Multiple(() =>
        {
            AssertRationalToString(2, 4, "1/2");
            AssertRationalToString(1, 2, "1/2");
            AssertRationalToString(3, 9, "1/3");
            AssertRationalToString(13, 25, "13/25");

            AssertRationalToString(12, 2, "6");
            AssertRationalToString(0, 7, "0");
            AssertRationalToString(1000, 10, "100");
        });
    }

    private static void AssertRationalToString(int numerator, int denominator, string expected)
    {
        That(new Rational(numerator, denominator).ToString(), Is.EqualTo(expected));
    }
}