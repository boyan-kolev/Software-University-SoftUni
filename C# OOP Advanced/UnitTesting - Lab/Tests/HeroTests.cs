
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void TestHeroGainXP()
    {
        //ITarget fakeTarget = new FakeTarget();
        //IWeapon fakeWeapon = new FakeWeapon();

        //Hero hero = new Hero(fakeWeapon, "Bobi");

        //hero.Attack(fakeTarget);

        //int expectedResult = 10;
        //int actualResult = hero.Experience;

        //Assert.AreEqual(expectedResult, actualResult);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Mock<ITarget> fakeTarget = new Mock<ITarget>();

        fakeWeapon.Setup(x => x.AttackPoints).Returns(10);
        fakeWeapon.Setup(x => x.DurabilityPoints).Returns(10);

        fakeTarget.Setup(x => x.Health).Returns(0);
        fakeTarget.Setup(x => x.GiveExperience()).Returns(10);
        fakeTarget.Setup(x => x.IsDead()).Returns(true);

        Hero hero = new Hero(fakeWeapon.Object, "Bobi");
        hero.Attack(fakeTarget.Object);

        int expectedResult = 10;
        int actualResult = hero.Experience;

        Assert.AreEqual(expectedResult, actualResult);

    }
}

