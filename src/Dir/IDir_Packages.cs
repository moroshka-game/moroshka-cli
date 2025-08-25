namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class Packages(string dir) : IDir
	{
		public Packages(IDir dir) : this(dir.Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, "Packages");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
