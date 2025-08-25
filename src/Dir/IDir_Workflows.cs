namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class Workflows(string dir) : IDir
	{
		public Workflows(IDir dir) : this(dir.Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, "workflows");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
