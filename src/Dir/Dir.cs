namespace Moroshka.Cli;

public sealed class Dir(string value) : IDir
{
	public Dir() : this(Environment.CurrentDirectory)
	{
	}

	public Dir(IName name) : this(name.Value())
	{
	}

	public string Value() => value;

	public void Create() => Directory.CreateDirectory(Value());

	public bool Exists() => Directory.Exists(Value());
}
