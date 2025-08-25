using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IVersion
{
	public sealed class Input(string defaultValue) : IVersion
	{
		public string Value()
		{
			while (true)
			{
				var name = AnsiConsole.Ask("[yellow]Enter version:[/]", defaultValue);
				if (!string.IsNullOrWhiteSpace(name)) return name;
			}
		}
	}
}
