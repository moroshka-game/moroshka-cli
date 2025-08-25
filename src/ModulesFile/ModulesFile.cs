using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Moroshka.Cli;

public sealed class ModulesFile(IYamlFile yamlFile) : IModulesFile
{
	public ModulesFile(ITextFile textFile) : this(
		new YamlFile(textFile,
			new DeserializerBuilder()
				.WithTypeConverter(new ModuleTypeConverter())
				.WithNamingConvention(UnderscoredNamingConvention.Instance)
				.Build(),
			new SerializerBuilder()
				.WithTypeConverter(new ModuleTypeConverter())
				.WithNamingConvention(UnderscoredNamingConvention.Instance)
				.Build()))
	{
	}

	public ModulesFile() : this(
		new TextFile(
			new File("modules.yaml",
				new IDir.Templates())))
	{
	}

	public IReadOnlyList<IModule> Read() => yamlFile.Read<List<Module>>();
}
