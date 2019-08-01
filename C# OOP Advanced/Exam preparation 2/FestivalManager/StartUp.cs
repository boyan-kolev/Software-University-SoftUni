namespace FestivalManager
{
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Entities;
    using FestivalManager.Core;
    using FestivalManager.Core.Contracts;
    using FestivalManager.Core.IO;
    using FestivalManager.Core.IO.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
			Stage stage = new Stage();
			IFestivalController festivalController = new FestivalController(stage);
			ISetController setController = new SetController(stage);

             IReader reader = new ConsoleReader();
             IWriter writer = new ConsoleWriter();

        IEngine engine = new Engine(
                festivalController, 
                setController,
                reader,
                writer
                );

			engine.Run();
		}
	}
}