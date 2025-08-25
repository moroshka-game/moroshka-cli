namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class Github(string dir) : IDir
	{
		public Github(IDir dir) : this(dir.Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, ".github");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
