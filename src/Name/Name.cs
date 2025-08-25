namespace Moroshka.Cli;

public sealed class Name(string name) : IName
{
	public Name() : this(
		new IName.Cache(
				new IName.Input())
			.Value())
	{
	}

	public string Value() => name;
}
