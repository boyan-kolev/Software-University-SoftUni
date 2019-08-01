namespace FestivalManager.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using FestivalManager.Entities.Sets;

    public class Stage : IStage
	{
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            IPerformer performer = this.performers.FirstOrDefault(x => x.Name == name);
            return performer;
        }

        public ISet GetSet(string name)
        {
            ISet set = this.sets.FirstOrDefault(x => x.Name == name);
            return set;
        }

        public ISong GetSong(string name)
        {
            ISong song = this.songs.FirstOrDefault(x => x.Name == name);
            return song;
        }

        public bool HasPerformer(string name)
        {
            bool isExists = this.performers.Any(x => x.Name == name);
            return isExists;
        }

        public bool HasSet(string name)
        {
            bool isExists = this.sets.Any(x => x.Name == name);
            return isExists;
        }

        public bool HasSong(string name)
        {
            bool isExists = this.songs.Any(x => x.Name == name);
            return isExists;
        }
    }
}
