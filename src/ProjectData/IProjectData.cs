namespace Moroshka.Cli;

public interface IProjectData
{
	string Version { get; }

	string Description { get; }

	AuthorData Author { get; }

	UnityData Unity { get; }

	string License { get; }

	string Dependencies { get; }
}
