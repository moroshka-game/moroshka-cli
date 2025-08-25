namespace Moroshka.Cli;

public sealed class Unity(string version, string release) : IUnity
{
	public Unity(IUnityData data) : this(
		new UnityVersion(data.Version).Value(),
		new UnityRelease(data.Release).Value())
	{
	}

	public Unity(IProjectData data) : this(data.Unity)
	{
	}

	public string Version() => version;

	public string Release() => release;
}
