using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IDependencies
{
	public sealed class InputDisplay(IIndexes indexes) : IIndexes
	{
		public IReadOnlyList<int> Values()
		{
			AnsiConsole.MarkupLine("[yellow]Dependencies:[/]");
			return indexes.Values();
		}
	}
}
