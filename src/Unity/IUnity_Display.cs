using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IUnity
{
	public sealed class Display(IUnity unity) : IUnity, IDisplay
	{
		public string Version() => unity.Version();

		public string Release() => unity.Release();

		public void Print()
		{
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddRow("Unity Version:", $"[green]{Version()}[/]")
				.AddRow("Unity Release:", $"[green]{Release()}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
