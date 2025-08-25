namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class UpmEditor(string dir) : IDir
	{
		public UpmEditor(IDir dir) : this(dir.Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, "Editor");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
