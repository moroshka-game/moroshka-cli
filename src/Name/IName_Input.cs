using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class Input : IName
	{
		public string Value()
		{
			while (true)
			{
				var name = AnsiConsole.Ask<string>("[yellow]Enter name:[/]");
				if (!string.IsNullOrWhiteSpace(name)) return name;
			}
		}
	}
}
