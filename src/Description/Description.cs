namespace Moroshka.Cli;

public sealed class Description(string value) : IDescription
{
	public Description(IProjectData data) : this(
		new IDescription.Cache(
			new IDescription.Input(data.Description))
			.Value())
	{
	}

	public string Value() => value;
}
