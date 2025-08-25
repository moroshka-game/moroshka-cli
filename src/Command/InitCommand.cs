using Spectre.Console.Cli;

namespace Moroshka.Cli;

internal sealed class InitCommand : Command
{
	public override int Execute(CommandContext context)
	{
		var repo = new GitConnectivity(
			new IRepo.Clear(
				new IRepo.Status(
					new GitRepo(
						new IUrl.Cache(
							new IUrl.Retry(
								new IUrl.Valid(
									new IUrl.Input("https://github.com/moroshka-game/moroshka-cli-templates")))),
						new IDir.Moroshka()))));
		return repo.Clone() ? 0 : 1;
	}
}
