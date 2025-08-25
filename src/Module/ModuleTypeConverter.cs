using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace Moroshka.Cli;

public sealed class ModuleTypeConverter : IYamlTypeConverter
{
	public bool Accepts(Type type) => type == typeof(Module);

	public object ReadYaml(IParser parser, Type type, ObjectDeserializer rootDeserializer)
	{
		var yamlObject = new DeserializerBuilder().Build()
			.Deserialize<Dictionary<string, string>>(parser);

		var url = yamlObject["url"];
		var name = yamlObject["name"];
		var version = yamlObject["version"];

		return new Module(url, name, version);
	}

	public void WriteYaml(IEmitter emitter, object? value, Type type, ObjectSerializer serializer)
	{
		throw new NotImplementedException();
	}
}