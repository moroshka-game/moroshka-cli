using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IEmail
{
	public sealed class Retry(IEmail email) : IEmail
	{
		public string Value()
		{
			while (true)
			{
				try
				{
					return email.Value();
				}
				catch (Exception ex)
				{
					AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
				}
			}
		}
	}
}
