using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IDescription
{
	public sealed class Display(IDescription description) : IDescription, IDisplay
	{
		public string Value() => description.Value();

		public void Print()
		{
			AnsiConsole.Write(
				new Grid()
					.AddColumn()
					.AddColumn()
					.AddRow("Description:", $"[green]{description.Value()}[/]"));
		}
	}
}
