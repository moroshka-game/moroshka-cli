using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IAuthor
{
	public sealed class Display(IAuthor author) : IAuthor, IDisplay
	{
		public string Name() => author.Name();

		public string Email() => author.Email();

		public void Print()
		{
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddRow("Author name:", $"[green]{Name()}[/]")
				.AddRow("Author email:", $"[green]{Email()}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
