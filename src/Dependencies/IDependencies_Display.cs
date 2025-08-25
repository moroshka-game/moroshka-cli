using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IDependencies
{
	public sealed class Display(IDependencies dependencies) : IDependencies, IDisplay
	{
		public IReadOnlyList<IModule> Modules() => dependencies.Modules();

		public void Print()
		{
			var modules = Modules();
			var names = modules.Select(module => module.DisplayName()).ToList();
			var grid = new Grid()
				.AddColumn()
				.AddColumn()
				.AddRow("Dependencies:", names.Count == 0 ? "none" : $"[green]{string.Join(", ", names)}[/]");
			AnsiConsole.Write(grid);
		}
	}
}
