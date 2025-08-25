namespace Moroshka.Cli;

public sealed class Module(IUrl url, IName name, IVersion version) : IModule
{
	public Module(string url, string name, string version)
		: this(new Url(url), new Name(name), new Version(version))
	{
	}

	public Module(IName name)
		: this(new Url(), name, new Version("1.0.0"))
	{
	}

	public string Name() => name.Value();

	public string UpmName() => new IName.UpmName(name).Value();

	public string DisplayName() => new IName.DisplayName(name).Value();

	public string RepoName() => new IName.KebabCase(new IName.Moroshka(name)).Value();

	public string Url() => url.Value();

	public string Version() => version.Value();
}
