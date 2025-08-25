using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IDependencies
{
	public sealed class ValidDisplay(IDependencies dependencies) : IDependencies, IDisplay
	{
		public IReadOnlyList<IModule> Modules() => dependencies.Modules();

		public void Print()
		{
			var modules = Modules();
			var names = modules.Select(module => module.DisplayName()).ToList();
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddColumn()
				.AddRow("[green]✓[/]", "Dependencies:", names.Count == 0 ? "none" : $"[green]{string.Join(", ", names)}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
