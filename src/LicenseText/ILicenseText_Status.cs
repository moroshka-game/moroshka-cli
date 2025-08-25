using Spectre.Console;

namespace Moroshka.Cli;

public partial interface ILicenseText
{
	public sealed class Status(ILicenseText license) : ILicenseText
	{
		public string Value()
		{
			try
			{
				return AnsiConsole.Status().Start("Download SPDX license text...", _ =>
				{
					var text = license.Value();
					return text;
				});
			}
			catch (Exception)
			{
				AnsiConsole.MarkupLine("[red]License text download error![/]");
				throw;
			}
		}
	}
}