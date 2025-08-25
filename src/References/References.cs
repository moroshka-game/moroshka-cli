namespace Moroshka.Cli;

public sealed class References(IDependencies dependencies) : IReferences
{
	public IReadOnlyList<string> Values() => [.. dependencies.Modules().Select(m => m.DisplayName())];
}
