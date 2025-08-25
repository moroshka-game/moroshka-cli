using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IVersion
{
	public sealed class Display(IVersion version) : IVersion, IDisplay
	{
		public string Value() => version.Value();

		public void Print()
		{
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddRow("Version:", $"[green]{version.Value()}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
