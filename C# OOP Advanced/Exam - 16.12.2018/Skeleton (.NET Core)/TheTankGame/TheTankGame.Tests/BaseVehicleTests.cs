namespace TheTankGame.Tests
{
    using NUnit.Framework;
    using TheTankGame.Entities.Miscellaneous;
    using TheTankGame.Entities.Parts;
    using TheTankGame.Entities.Parts.Contracts;
    using TheTankGame.Entities.Vehicles;

    [TestFixture]
    public class BaseVehicleTests
    {
        [Test]
        public void test1()
        {
            BaseVehicle baseVehicle = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, new VehicleAssembler());

            IPart part = new ArsenalPart("SA-203", 20, 20, 20);

            baseVehicle.AddArsenalPart(part);

            var result = 120;
            var actualResult = baseVehicle.TotalWeight;

            Assert.AreEqual(result, actualResult);

        }

        [Test]
        public void test2()
        {
            BaseVehicle baseVehicle = new Vanguard("SA-203", 100, 300, 1000, 450, 2000, new VehicleAssembler());

            IPart part = new ArsenalPart("SA-203", 20, 20, 20);

            baseVehicle.AddArsenalPart(part);

            var result = 2000;
            var actualResult = baseVehicle.TotalHitPoints;

            Assert.AreEqual(result, actualResult);
        }
    }
}