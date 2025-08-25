using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class Display(IName name) : IName, IDisplay
	{
		public string Value() => name.Value();

		public void Print()
		{
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddRow("Name:", $"[green]{name.Value()}[/]")
				.AddRow("UPM Name:", $"[green]{new UpmName(name).Value()}[/]")
				.AddRow("Display Name:", $"[green]{new DisplayName(name).Value()}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
