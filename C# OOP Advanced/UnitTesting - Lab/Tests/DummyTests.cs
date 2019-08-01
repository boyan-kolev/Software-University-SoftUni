
using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private const int DummyExperience = 10;
    private Dummy dummy;

    [Test]
    public void DummyLosesAttacHealthIfAttacked()
    {
        dummy = new Dummy(10, DummyExperience);

        dummy.TakeAttack(5);

        Assert.That(dummy.Health, Is.EqualTo(5), "dumy lose health, when he is attacked");
    }

    [Test]
    public void DeadDummyThrowsAnExceptionIfAttacked()
    {
        dummy = new Dummy(0, DummyExperience);

        Assert.That(() => dummy.TakeAttack(10),
            Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyCanGiveXP()
    {
        dummy = new Dummy(0, DummyExperience);

        int expectedResult = 10;
        int actualResult = dummy.GiveExperience();

        Assert.AreEqual(expectedResult, actualResult, "Dead dummy can give experience !");
    }

    [Test]
    public void AliveDummyCantGiveXP()
    {
        dummy = new Dummy(10, DummyExperience);

        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }

}
