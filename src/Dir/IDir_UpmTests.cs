namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class UpmTests(string dir) : IDir
	{
		public UpmTests(IDir dir) : this(dir.Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, "Tests");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
