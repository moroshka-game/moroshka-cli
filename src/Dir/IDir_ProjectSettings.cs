namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class ProjectSettings(string dir) : IDir
	{
		public ProjectSettings(IDir dir) : this(dir.Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, "ProjectSettings");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
