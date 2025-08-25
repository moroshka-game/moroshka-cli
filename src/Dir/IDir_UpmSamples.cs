namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class UpmSamples(string dir) : IDir
	{
		public UpmSamples(IDir dir) : this(dir.Value())
		{
		}

		public string Value() => Path.Combine(dir, "Samples~");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
