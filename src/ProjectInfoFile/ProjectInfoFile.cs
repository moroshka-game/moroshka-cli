using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Moroshka.Cli;

public sealed class ProjectInfoFile(ProjectData data) : IProjectInfoFile
{
	public ProjectInfoFile(YamlFile yamlFile) : this(yamlFile.Read<ProjectData>())
	{
	}

	public ProjectInfoFile(ITextFile textFile) : this(
		new YamlFile(textFile,
			new DeserializerBuilder()
				.WithNamingConvention(UnderscoredNamingConvention.Instance)
				.Build(),
			new SerializerBuilder()
				.WithNamingConvention(UnderscoredNamingConvention.Instance)
				.Build()))
	{
	}

	public ProjectInfoFile() : this(
			new TextFile(
				new File("default-project.yaml",
					new IDir.Templates())))
	{
	}

	public IProjectData Data() => data;
}
