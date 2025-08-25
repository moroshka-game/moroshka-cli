namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class UpmRuntime(string dir) : IDir
	{
		public UpmRuntime(IDir dir) : this(dir.Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, "Runtime");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
