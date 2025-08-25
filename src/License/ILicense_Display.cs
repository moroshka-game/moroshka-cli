using Spectre.Console;

namespace Moroshka.Cli;

public partial interface ILicense
{
	public sealed class Display(ILicense license) : ILicense, IDisplay
	{
		public string Value() => license.Value();

		public void Print()
		{
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddRow("License (SPDX):", $"[green]{license.Value()}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
