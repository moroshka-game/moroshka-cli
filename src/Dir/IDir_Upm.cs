namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class Upm(string dir) : IDir
	{
		public Upm(IDir dir) : this(dir.Value())
		{
			Create();
		}

		public Upm() : this(new Dir())
		{
		}

		public string Value() => Path.Combine(dir, "upm");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
