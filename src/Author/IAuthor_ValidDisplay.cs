using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IAuthor
{
	public sealed class ValidDisplay(IAuthor author) : IAuthor, IDisplay
	{
		public string Name() => author.Name();

		public string Email() => author.Email();

		public void Print()
		{
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddColumn()
				.AddRow("[green]✓[/]", "Author name:", $"[green]{Name()}[/]")
				.AddRow("[green]✓[/]", "Author email:", $"[green]{Email()}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
