using Spectre.Console;

namespace Moroshka.Cli;

public sealed class GitConnectivity(IRepo repo) : IRepo
{
	public string Path() => repo.Path();

	public string Url() => repo.Url();

	public bool Clone()
	{
		return StatusStart() && repo.Clone();
	}

	private static bool CheckConnection(string url)
	{
		try
		{
			using var process = new System.Diagnostics.Process();
			process.StartInfo = new System.Diagnostics.ProcessStartInfo
			{
				FileName = "git",
				Arguments = $"ls-remote {url} HEAD",
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false,
				CreateNoWindow = true
			};

			process.Start();
			process.WaitForExit();
			return process.ExitCode == 0;
		}
		catch (Exception)
		{
			return false;
		}
	}

	private bool StatusStart()
	{
		var url = repo.Url();
		return AnsiConsole.Status().Start("Connection...", _ =>
		{
			var result = CheckConnection(url);
			AnsiConsole.MarkupLine(result ? "[green]Connection succeeded.[/]" : "[red]Connection error![/]");
			return result;
		});
	}
}
