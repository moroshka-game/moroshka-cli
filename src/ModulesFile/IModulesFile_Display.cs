using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IModulesFile
{
	public sealed class Display(IModulesFile modulesFile) : IModulesFile, IDisplay
	{
		public IReadOnlyList<IModule> Read() => modulesFile.Read();

		public void Print()
		{
			var modules = modulesFile.Read();
			var table = new Grid()
				.AddColumn()
				.AddColumn()
				.AddColumn()
				.AddColumn();

			for (var i = 0; i < modules.Count; i++)
			{
				var module = modules[i];
				table.AddRow(
					new Text($"[{i}]"),
					new Text(module.DisplayName(), new Style(Color.Green)),
					new Text(module.Version()),
					new Text(module.Url()));
			}

			AnsiConsole.Write(table);
		}
	}
}
