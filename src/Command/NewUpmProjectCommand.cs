using Spectre.Console.Cli;

namespace Moroshka.Cli;

public sealed class NewUpmProjectCommand : Command
{
	public override int Execute(CommandContext context)
	{
		var projectInfo = new ProjectInfo();
		var projectDir = new IDir.Project(projectInfo);

		var mainProjectDir = new IDir.MainProject(projectDir, projectInfo);
		var testsProjectDir = new IDir.TestsProject(projectDir, projectInfo);

		new SolutionFile(projectDir, projectInfo).Create();
		new MainProjectFile(mainProjectDir, projectInfo).Create();
		new TestProjectFile(testsProjectDir, projectInfo).Create();

		var unityDir = new IDir.Unity(projectDir, projectInfo);
		var projectSettingsDir = new IDir.ProjectSettings(unityDir);
		var packagesDir = new IDir.Packages(unityDir);
		new IDir.Assets(unityDir).Create();
		new LicenseFile(projectDir, projectInfo).Create();
		new ReadmeFile(projectDir, projectInfo).Create();
		new GitignoreFile(projectDir).Create();
		new ProjectVersionFile(projectSettingsDir, projectInfo).Create();
		new ManifestFile(packagesDir).Create();

		var upmDir = new IDir.Upm(projectDir);
		new IDir.UpmDocumentation(upmDir).Create();
		new IDir.UpmSamples(upmDir).Create();
		new ReadmeFile(upmDir, projectInfo).Create();
		new ChangeLogFile(upmDir).Create();
		new UpmManifestFile(upmDir, projectInfo).Create();
		new IAsmdefFile.Default(upmDir, projectInfo).Create();
		new IAsmdefFile.Editor(upmDir, projectInfo).Create();
		new IAsmdefFile.Tests(upmDir, projectInfo).Create();

		var githubDir = new IDir.Github(projectDir);
		var workflowsDir = new IDir.Workflows(githubDir);
		new SyncUpmFile(workflowsDir).Create();

		return 0;
	}
}
