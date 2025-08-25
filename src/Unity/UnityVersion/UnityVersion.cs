namespace Moroshka.Cli;

public sealed class UnityVersion(string value) : IUnityVersion
{
	public UnityVersion() : this(
		new IUnityVersion.Retry(
				new IUnityVersion.Valid(
					new IUnityVersion.Input("6000.2")))
			.Value())
	{
	}

	public string Value() => value;
}
