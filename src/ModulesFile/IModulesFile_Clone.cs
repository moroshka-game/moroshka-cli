using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IModulesFile
{
	public sealed class Clone(IModulesFile modulesFile)
	{
		public void Execute()
		{
			var modules = modulesFile.Read();
			AnsiConsole.Status().Start("Clone...", _ =>
			{
				foreach (var module in modules)
				{
					AnsiConsole.MarkupLine(CloneModule(module)
						? $"[green] ✓ {module.DisplayName()}[/]"
						: $"[red] ✗ {module.DisplayName()}[/]");
				}
			});
		}

		private static bool CloneModule(IModule module)
		{
			var repo = new GitRepo(
				new Url(module.Url()),
				new Dir(module.RepoName()));
			return repo.Clone();
		}
	}
}
