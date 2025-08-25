namespace Moroshka.Cli;

[Serializable]
public sealed class UnityData : IUnityData
{
	public string Version { get; init; } = "6000.2";

	public string Release { get; init; } = "0f1";
}
