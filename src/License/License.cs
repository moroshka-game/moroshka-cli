namespace Moroshka.Cli;

public sealed class License(string spdxId) : ILicense
{
	public License(IProjectData data) : this(
		new ILicense.Cache(
				new ILicense.Input(data.License))
			.Value())
	{
	}

	public string Value() => spdxId;
}
