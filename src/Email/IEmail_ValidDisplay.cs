using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IEmail
{
	public sealed class ValidDisplay(IEmail email) : IEmail, IDisplay
	{
		public string Value() => email.Value();

		public void Print()
		{
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddColumn()
				.AddRow("[green]✓[/]", "Email:", $"[green]{email.Value()}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
