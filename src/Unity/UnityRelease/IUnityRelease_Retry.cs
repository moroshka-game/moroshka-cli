using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IUnityRelease
{
	public sealed class Retry(IUnityRelease version) : IUnityRelease
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