using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private const int DummyHealth = 10;
    private const int DummyExperience = 10;

    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.dummy = new Dummy(DummyHealth, DummyExperience);
    }

    [Test]
    public void TestIfWeaponLosesDurabilityAfterEachAttack()
    {
        //arrange
        Axe axe = new Axe(10, 10);

        //Act
        axe.Attack(dummy);

        //Assert
        int expectedResult = 9;
        int actualResult = axe.DurabilityPoints;

        Assert.AreEqual(expectedResult, actualResult, "Axe durability doesn,t change after attack.");
    }

    [Test]
    public void TestAttackingWithABrokenWeapon()
    {
        Axe axe = new Axe(10, 0);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy), "Axe is broken !");

        //Assert.That(() => axe.Attack(dummy),
        //    Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
    }


}