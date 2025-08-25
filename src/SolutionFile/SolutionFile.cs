using System.Text;

namespace Moroshka.Cli;

public sealed class SolutionFile(ITextFile outputFile, IProjectInfo projectInfo) : ISolutionFile
{
	public SolutionFile(IDir dir, IProjectInfo projectInfo) : this(
		new TextFile($"{new IName.DisplayName(projectInfo.Name()).Value()}.sln", dir),
		projectInfo)
	{
	}

	public void Create()
	{
		var projectName = new IName.DisplayName(projectInfo.Name()).Value();
		var projectDir = new IName.KebabCase(new IName.Moroshka(projectInfo.Name())).Value();
		var mainProjectGuid = Guid.NewGuid().ToString("D").ToUpper();
		var testProjectGuid = Guid.NewGuid().ToString("D").ToUpper();

		var content = $@"Microsoft Visual Studio Solution File, Format Version 12.00
Project(""{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}"") = ""{projectName}"", ""{projectDir}\{projectName}.csproj"", ""{{{mainProjectGuid}}}""
EndProject
Project(""{{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}}"") = ""{projectName}.Tests"", ""{projectDir}-tests\{projectName}.Tests.csproj"", ""{{{testProjectGuid}}}""
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{{{mainProjectGuid}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{{mainProjectGuid}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{{mainProjectGuid}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{{mainProjectGuid}}}.Release|Any CPU.Build.0 = Release|Any CPU
		{{{testProjectGuid}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{{{testProjectGuid}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{{{testProjectGuid}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{{{testProjectGuid}}}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
EndGlobal";

		outputFile.Write(content);
	}
}
