using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class ValidDisplay(IName name) : IName, IDisplay
	{
		public string Value() => name.Value();

		public void Print()
		{
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddColumn()
				.AddRow("[green]✓[/]", "Name:", $"[green]{name.Value()}[/]")
				.AddRow("[green]✓[/]", "UPM Name:", $"[green]{new UpmName(name).Value()}[/]")
				.AddRow("[green]✓[/]", "Display Name:", $"[green]{new DisplayName(name).Value()}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
