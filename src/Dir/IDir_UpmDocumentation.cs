namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class UpmDocumentation(string dir) : IDir
	{
		public UpmDocumentation(IDir dir) : this(dir.Value())
		{
		}

		public string Value() => Path.Combine(dir, "Documentation~");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
