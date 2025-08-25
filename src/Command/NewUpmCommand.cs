using Spectre.Console.Cli;

namespace Moroshka.Cli;

public sealed class NewUpmCommand : Command
{
	public override int Execute(CommandContext context)
	{
		var projectInfo = new ProjectInfo();
		var upmDir = new IDir.Upm();

		new LicenseFile(upmDir, projectInfo).Create();
		new ReadmeFile(upmDir, projectInfo).Create();
		new ChangeLogFile(upmDir).Create();
		new UpmManifestFile(upmDir, projectInfo).Create();
		new IAsmdefFile.Default(upmDir, projectInfo).Create();
		new IAsmdefFile.Editor(upmDir, projectInfo).Create();
		new IAsmdefFile.Tests(upmDir, projectInfo).Create();

		return 0;
	}
}
