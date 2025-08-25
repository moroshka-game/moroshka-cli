using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IUnity
{
	public sealed class ValidDisplay(IUnity unity) : IUnity, IDisplay
	{
		public string Version() => unity.Version();

		public string Release() => unity.Release();

		public void Print()
		{
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddColumn()
				.AddRow("[green]✓[/]", "Unity Version:", $"[green]{Version()}[/]")
				.AddRow("[green]✓[/]", "Unity Release:", $"[green]{Release()}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
