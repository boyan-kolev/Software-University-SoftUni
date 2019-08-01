namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Linq;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

		private readonly IStage stage;
        private IInstrumentFactory instrumentFactory;
        private ISetFactory setFactory;

		public FestivalController(IStage stage)
		{
			this.stage = stage;
            this.instrumentFactory = new InstrumentFactory();
            this.setFactory = new SetFactory();
		}


		public string RegisterSet(string[] args)
		{
            string name = args[0];
            string type = args[1];
            ISet set = this.setFactory.CreateSet(name, type);

            this.stage.AddSet(set);
            string result = $"Registered {type} set";

            return result;
		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var instrumentsTypes = args.Skip(2).ToArray();

			IInstrument[] instruments = instrumentsTypes
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			IPerformer performer = new Performer(name, age);

			foreach (var instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
            string name = args[0];

            string[] durationTokens = args[1].Split(":");
            int minutes = int.Parse(durationTokens[0]);
            int seconds = int.Parse(durationTokens[1]);

            TimeSpan duration = new TimeSpan(0, minutes, seconds);

            ISong song = new Song(name, duration);
            this.stage.AddSong(song);

            string result = $"Registered song {name} ({duration:mm\\:ss})";
            return result;
        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            ISong song = this.stage.GetSong(songName);
            ISet set = this.stage.GetSet(setName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }


            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }
		
		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}

        public string ProduceReport()
        {
            string result = string.Empty;

            TimeSpan totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));
            int minutes = totalFestivalLength.Hours * 60 + totalFestivalLength.Minutes;
            int seconds = totalFestivalLength.Seconds;

            result += ($"Festival length: {minutes:d2}:{seconds:d2}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                TimeSpan setLength = set.ActualDuration;
                int minutesSet = setLength.Hours * 60 + setLength.Minutes;
                int secondsSet = setLength.Seconds;
                result += ($"--{set.Name} ({minutesSet:d2}:{secondsSet:d2}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString();
        }

    }
}