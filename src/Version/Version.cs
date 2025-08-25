namespace Moroshka.Cli;

public sealed class Version(string version) : IVersion
{
	public Version(IProjectData data) : this(
		new IVersion.Cache(
			new IVersion.Retry(
				new IVersion.Valid(
					new IVersion.Input(data.Version))))
			.Value())
	{
	}

	public string Value() => version;
}
