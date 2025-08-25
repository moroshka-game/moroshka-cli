using System.Text.Json;
namespace Moroshka.Cli;

public sealed class UpmManifestFile(
	IJsonFile jsonFile,
	IProjectInfo projectInfo) : IUpmManifestFile
{
	public UpmManifestFile(IDir dir, IProjectInfo projectInfo)
		: this(
			new JsonFile(dir, "package.json", new JsonSerializerOptions { WriteIndented = true }),
			projectInfo)
	{
	}

	public void Create()
	{
		jsonFile.Write(new ManifestDto
		{
			name = new IName.UpmName(projectInfo.Name()).Value(),
			displayName = new IName.DisplayName(projectInfo.Name()).Value(),
			version = projectInfo.Version().Value(),
			description = projectInfo.Description().Value(),
			unity = projectInfo.Unity().Version(),
			unityRelease = projectInfo.Unity().Release(),
			author = new AuthorDto
			{
				name = projectInfo.Author().Name(),
				email = projectInfo.Author().Email()
			},
			license = projectInfo.License().Value(),
			dependencies = projectInfo.Dependencies().Modules()
				.ToDictionary(m => m.UpmName(), m => m.Version())
		});
	}

	private sealed class ManifestDto
	{
		public string name { get; init; } = string.Empty;
		public string displayName { get; init; } = string.Empty;
		public string version { get; init; } = string.Empty;
		public string description { get; init; } = string.Empty;
		public string unity { get; init; } = string.Empty;
		public string unityRelease { get; init; } = string.Empty;
		public AuthorDto author { get; init; } = new();
		public string license { get; init; } = string.Empty;
		public Dictionary<string, string> dependencies { get; init; } = new();
	}

	private sealed class AuthorDto
	{
		public string name { get; init; } = string.Empty;
		public string email { get; init; } = string.Empty;
	}
}
