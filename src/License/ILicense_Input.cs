using Spectre.Console;

namespace Moroshka.Cli;

public partial interface ILicense
{
	public sealed class Input(string defaultValue) : ILicense
	{
		public string Value()
		{
			while (true)
			{
				var id = AnsiConsole.Ask("[yellow]Enter SPDX license id:[/]", defaultValue);
				if (!string.IsNullOrWhiteSpace(id)) return id.Trim();
			}
		}
	}
}
