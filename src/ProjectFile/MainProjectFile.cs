using System.Text;

namespace Moroshka.Cli;

public sealed class MainProjectFile(ITextFile outputFile, IProjectInfo projectInfo) : IProjectFile
{
	public MainProjectFile(IDir dir, IProjectInfo projectInfo) : this(
		new TextFile($"{new IName.DisplayName(projectInfo.Name()).Value()}.csproj", dir),
		projectInfo)
	{
	}

	public void Create()
	{
		var displayName = new IName.DisplayName(projectInfo.Name());
		var displayNameValue = displayName.Value();
		var authorName = projectInfo.Author().Name();
		var authorEmail = projectInfo.Author().Email();
		var versionValue = projectInfo.Version().Value();
		var descriptionValue = projectInfo.Description().Value();

		var content = new StringBuilder();
		content.AppendLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
		content.AppendLine();
		content.AppendLine("    <PropertyGroup>");
		content.AppendLine("        <TargetFramework>net6.0</TargetFramework>");
		content.AppendLine("        <Nullable>disable</Nullable>");
		content.AppendLine("        <LangVersion>9</LangVersion>");
		content.AppendLine("        <GeneratePackageOnBuild>true</GeneratePackageOnBuild>");
		content.AppendLine($"        <Title>{displayNameValue}</Title>");
		content.AppendLine($"        <Authors>{authorName} ({authorEmail})</Authors>");
		content.AppendLine($"        <Copyright>Copyright (c) 2025 {authorName} ({authorEmail})</Copyright>");
		content.AppendLine("        <RepositoryType>Git</RepositoryType>");
		content.AppendLine($"        <Version>{versionValue}</Version>");
		content.AppendLine($"        <PackageId>{displayNameValue}</PackageId>");
		content.AppendLine($"        <Description>{descriptionValue}</Description>");
		content.AppendLine("        <PackageLicenseFile>LICENSE.md</PackageLicenseFile>");
		content.AppendLine("        <PackageReadmeFile>README.md</PackageReadmeFile>");
		content.AppendLine("        <PackageTags>unity</PackageTags>");
		content.AppendLine($"        <AssemblyName>{displayNameValue}</AssemblyName>");
		content.AppendLine($"        <RootNamespace>{displayNameValue}</RootNamespace>");
		content.AppendLine("    </PropertyGroup>");
		content.AppendLine();
		content.AppendLine("    <ItemGroup>");
		content.AppendLine("        <None Include=\"..\\README.md\" Pack=\"true\" PackagePath=\"\\\" />");
		content.AppendLine("        <None Include=\"..\\LICENSE.md\" Pack=\"true\" PackagePath=\"\\\" />");
		content.AppendLine("    </ItemGroup>");
		content.AppendLine();
		content.AppendLine("</Project>");
		outputFile.Write(content.ToString());
	}
}
