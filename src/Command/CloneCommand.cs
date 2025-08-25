using Spectre.Console.Cli;

namespace Moroshka.Cli;

public sealed class CloneCommand : Command
{
	public override int Execute(CommandContext context)
	{
		var modulesFile = new ModulesFile();

		new IModulesFile.Clone(
				new IModulesFile.Cache(
					new IModulesFile.Where(modulesFile,
						new IIndexes.RetryInput(
							new IIndexes.Input(modulesFile)))))
			.Execute();
		return 0;
	}
}
