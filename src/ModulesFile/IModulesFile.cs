namespace Moroshka.Cli;

public partial interface IModulesFile
{
	IReadOnlyList<IModule> Read();
}
