using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IVersion
{
	public sealed class Retry(IVersion version) : IVersion
	{
		public string Value()
		{
			while (true)
			{
				try
				{
					return version.Value();
				}
				catch (Exception ex)
				{
					AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
				}
			}
		}
	}
}
