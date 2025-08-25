namespace Moroshka.Cli;

public partial interface IDependencies
{
	public IReadOnlyList<IModule> Modules();
}
