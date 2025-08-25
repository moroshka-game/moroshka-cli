namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class Moroshka(string dir) : IDir
	{
		public Moroshka() : this(new Dir().Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, ".moroshka");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
