namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class Assets(string dir) : IDir
	{
		public Assets(IDir dir) : this(dir.Value())
		{
		}

		public string Value() => Path.Combine(dir, "Assets");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
