namespace Moroshka.Cli;

public sealed class GitRepo(IUrl url, IDir dir) : IRepo
{
	public string Path() => dir.Value();

	public string Url() => url.Value();

	public bool Clone()
	{
		try
		{
			using var process = new System.Diagnostics.Process();
			process.StartInfo = new System.Diagnostics.ProcessStartInfo
			{
				FileName = "git",
				Arguments = $"clone {url.Value()} {dir.Value()}",
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
}
