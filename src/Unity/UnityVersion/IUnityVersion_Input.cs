using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IUnityVersion
{
	public sealed class Input(string defaultValue) : IUnityVersion
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