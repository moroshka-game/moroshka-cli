using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IRepo
{
	public sealed class Status(IRepo repo) : IRepo
	{
		public string Path() => repo.Path();

		public string Url() => repo.Url();

		public bool Clone()
		{
			return AnsiConsole.Status().Start("Clone...", _ =>
			{
				var result = repo.Clone();
				AnsiConsole.MarkupLine(result ? "[green]Clone succeeded.[/]" : "[red]Clone error![/]");
				return result;
			});
		}
	}
}
