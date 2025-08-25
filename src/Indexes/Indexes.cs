namespace Moroshka.Cli;

public sealed class Indexes(IReadOnlyList<int> values) : IIndexes
{
	public IReadOnlyList<int> Values() => values;
}
