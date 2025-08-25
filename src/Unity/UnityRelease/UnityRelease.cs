namespace Moroshka.Cli;

public sealed class UnityRelease(string value) : IUnityRelease
{
	public UnityRelease() : this(
		new IUnityRelease.Retry(
				new IUnityRelease.Valid(
					new IUnityRelease.Input("0f1")))
			.Value())
	{
	}

	public string Value() => value;
}
