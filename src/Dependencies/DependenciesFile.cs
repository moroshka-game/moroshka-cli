namespace Moroshka.Cli;

public sealed class DependenciesFile(IModulesFile file) : IDependencies
{
	public IReadOnlyList<IModule> Modules() => file.Read();
}
