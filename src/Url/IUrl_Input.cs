using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IUrl
{
	public sealed class Input(string defaultValue) : IUrl
	{
		public string Value()
		{
			while (true)
			{
				var value = AnsiConsole.Ask("[yellow]Enter url:[/]", defaultValue);
				if (!string.IsNullOrWhiteSpace(value)) return value;
			}
		}
	}
}
