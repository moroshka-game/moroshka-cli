using System.Text;

namespace Moroshka.Cli;

public sealed class TestProjectFile(ITextFile outputFile, IProjectInfo projectInfo) : IProjectFile
{
	public TestProjectFile(IDir dir, IProjectInfo projectInfo) : this(
		new TextFile($"{new IName.DisplayName(projectInfo.Name()).Value()}.Tests.csproj", dir),
		projectInfo)
	{
	}

	public void Create()
	{
		var projectDir = new IName.KebabCase(new IName.Moroshka(projectInfo.Name())).Value();
		var displayName = new IName.DisplayName(projectInfo.Name());
		var content = new StringBuilder();
		content.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
		content.AppendLine();
		content.AppendLine("    <PropertyGroup>");
		content.AppendLine("        <TargetFramework>net6.0</TargetFramework>");
		content.AppendLine("        <Nullable>disable</Nullable>");
		content.AppendLine("        <LangVersion>9</LangVersion>");
		content.AppendLine("    </PropertyGroup>");
		content.AppendLine();
		content.AppendLine("    <ItemGroup>");
		content.AppendLine("      <PackageReference Include=\"Microsoft.NET.Test.Sdk\" Version=\"17.13.0\" />");
		content.AppendLine("      <PackageReference Include=\"NUnit\" Version=\"4.1.0\" />");
		content.AppendLine("    </ItemGroup>");
		content.AppendLine();
		content.AppendLine("    <ItemGroup>");
		content.AppendLine($"      <ProjectReference Include=\"..\\{projectDir}\\{displayName.Value()}.csproj\" />");
		content.AppendLine("    </ItemGroup>");
		content.AppendLine();
		content.AppendLine("</Project>");
		outputFile.Write(content.ToString());
	}
}
