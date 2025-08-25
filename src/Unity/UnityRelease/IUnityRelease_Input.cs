using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IUnityRelease
{
	public sealed class Input(string defaultValue) : IUnityRelease
	{
		public string Value()
		{
			while (true)
			{
				var version = AnsiConsole.Ask("[yellow]Enter Unity version:[/]", defaultValue);
				if (!string.IsNullOrWhiteSpace(version)) return version;
			}
		}
	}
}