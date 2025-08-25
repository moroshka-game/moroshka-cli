namespace Moroshka.Cli;

[Serializable]
public sealed class ProjectData : IProjectData
{
	public string Version { get; init; } = "1.0.0";

	public string Description { get; init; } = "TODO: Description";

	public AuthorData Author { get; init; } = new AuthorData();

	public UnityData Unity { get; init; } = new UnityData();

	public string License { get; init; } = "MIT";

	public string Dependencies { get; init; } = "none";
}
