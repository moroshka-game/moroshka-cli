namespace Moroshka.Cli;

public sealed class Separators(IEnumerable<char> separators) : ISeparators
{
	public Separators() : this([' ', '-', '_', '.', ',', ';', ':', '\t', '\n', '\r'])
	{
	}

	public bool Separator(char separator) => separators.Contains(separator);
}
