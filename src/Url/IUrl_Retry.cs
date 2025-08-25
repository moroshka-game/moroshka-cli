using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IUrl
{
	public sealed class Retry(IUrl url) : IUrl
	{
		public string Value()
		{
			while (true)
			{
				try
				{
					return url.Value();
				}
				catch (Exception ex)
				{
					AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
				}
			}
		}
	}
}
