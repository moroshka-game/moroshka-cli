namespace Moroshka.Cli;

public interface IModule
{
	string Name();

	string UpmName();

	string DisplayName();

	string RepoName();

	string Url();

	string Version();
}
