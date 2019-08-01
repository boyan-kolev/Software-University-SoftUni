namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class SetControllerTests
    {
		[Test]
	    public void SetControllerShouldReturnFailMessage()
	    {
            IStage stage = new Stage();
            ISet set = new Long("Pesho");

            stage.AddSet(set);

            ISetController setController = new SetController(stage);

            string expectedResult = "1. Pesho:\r\n-- Did not perform";
            string actualResult = setController.PerformSets();

            Assert.That(actualResult, Is.EqualTo(expectedResult));
		}

        [Test]
        public void SetControllerShouldReturnSuccessMessage()
        {

            ISet set = new Long("Pesho");
            IInstrument instrument = new Guitar();
            IPerformer performer = new Performer("bobi", 22);
            performer.AddInstrument(instrument);

            ISong song = new Song("kiro", new TimeSpan(0, 2, 30));

            set.AddPerformer(performer);
            set.AddSong(song);

            IStage stage = new Stage();
            stage.AddSet(set);
            ISetController setController = new SetController(stage);

            string expectedResult = "1. Pesho:\r\n-- 1. kiro (02:30)\r\n-- Set Successful";
            string actualResult = setController.PerformSets();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void PerformSetsShouldDecreaseInstruments()
        {
            ISet set = new Long("Pesho");
            IInstrument instrument = new Guitar();
            IPerformer performer = new Performer("bobi", 22);
            performer.AddInstrument(instrument);

            ISong song = new Song("kiro", new TimeSpan(0, 2, 30));

            set.AddPerformer(performer);
            set.AddSong(song);

            IStage stage = new Stage();
            stage.AddSet(set);
            ISetController setController = new SetController(stage);
            setController.PerformSets();

            double actualResult = instrument.Wear;
            double expectedResult = 40;
            Assert.AreEqual(expectedResult, actualResult);
        }
	}
}