using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Task1;

public class Phase3Test
{
    [Test]
    public void TestOperators()
    {
        var r1 = new Rational(1, 6);
        var r2 = new Rational(1, 5);
        Multiple(() =>
        {
            // Fail("Раскомментируйте тесты ниже и реализуйте требуемую функциональность в классе Rational");
            /* Читайте про перегрузку операторов на https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading */
            /* пример сигнатуры функции public static Rational operator +(Rational r1, Rational r2)*/
            That(r1 + r2, Is.EqualTo(new Rational(11, 30)));
            That(r1 * r2, Is.EqualTo(new Rational(1, 30)));
            That(r1 / r2, Is.EqualTo(new Rational(5, 6)));
            That(r1 > r2, Is.False);
            // ReSharper disable once EqualExpressionComparison
            That(r1 >= r1, Is.False);
            That(r1 != -r1, Is.True);
        });
    }
}