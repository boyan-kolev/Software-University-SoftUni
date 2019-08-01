namespace FestivalManager.Entities
{
	using System;
	using Contracts;

	public class Song : ISong
    {
		public Song(string name, TimeSpan duration)
		{
			this.Name = name;
			this.Duration = duration;
		}

		public string Name { get; private set; }

	    public TimeSpan Duration { get; private set; }

        //TODO might be a bug !!!
	    public override string ToString()
	    {
		    return $"{this.Name} ({this.Duration:mm\\:ss})";
	    }
    }
}
