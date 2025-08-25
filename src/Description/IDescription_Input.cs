using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IDescription
{
	public sealed class Input(string defaultValue) : IDescription
	{
		public string Value()
		{
			while (true)
			{
				var value = AnsiConsole.Ask("[yellow]Enter description[/]", defaultValue);
				if (!string.IsNullOrWhiteSpace(value)) return value;
			}
		}
	}
}
