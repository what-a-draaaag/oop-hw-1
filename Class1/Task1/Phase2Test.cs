using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace Task1;

public class Phase2Test
{
    [Test]
    public void TestSecondaryConstructors()
    {
        var r = new Rational(-4, 3);
        Multiple(() =>
        {
            // Fail("Раскомментируйте тесты ниже и реализуйте требуемую функциональность в классе Rational");
            That(new Rational(-2, 5, 3), Is.EqualTo(r));
            That(new Rational(0, -4, 3), Is.EqualTo(r));
            That(new Rational(r), Is.EqualTo(r));
            That(new Rational("-4/3"), Is.EqualTo(r));
            That(new Rational("-24/18"), Is.EqualTo(r));
        });
    }
}