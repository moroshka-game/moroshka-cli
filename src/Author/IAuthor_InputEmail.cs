using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IAuthor
{
	public sealed class InputEmail(string defaultValue) : IEmail
	{
		public string Value() => AnsiConsole.Ask("[yellow]Enter author email[/]", defaultValue);
	}
}
