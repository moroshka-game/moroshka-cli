using YamlDotNet.Serialization;

namespace Moroshka.Cli;

public sealed class YamlFile(ITextFile textFile, IDeserializer deserializer, ISerializer serializer) : IYamlFile
{
	public YamlFile(IFile file, IDeserializer deserializer, ISerializer serializer)
		: this(new TextFile(file), deserializer, serializer)
	{
	}

	public YamlFile(string path, IDeserializer deserializer, ISerializer serializer)
		: this(new TextFile(path), deserializer, serializer)
	{
	}

	public YamlFile(string dir, string name, IDeserializer deserializer, ISerializer serializer)
		: this(new TextFile(dir, name), deserializer, serializer)
	{
	}

	public YamlFile(IDir dir, string name, IDeserializer deserializer, ISerializer serializer)
		: this(new TextFile(name, dir), deserializer, serializer)
	{
	}

	public string Path() => textFile.Path();

	public bool Exists() => textFile.Exists();

	public string Read()
	{
		try
		{
			return textFile.Read();
		}
		catch (Exception e)
		{
			throw new Exception($"Failed to read yaml file: {Path()}", e);
		}
	}

	public void Write(string content)
	{
		try
		{
			textFile.Write(content);
		}
		catch (Exception e)
		{
			throw new Exception($"Failed to write yaml file: {Path()}", e);
		}
	}

	public T Read<T>()
	{
		var yaml = Read();
		return Deserialize<T>(yaml);
	}

	public void Write<T>(T obj)
	{
		var yaml = Serialize(obj);
		textFile.Write(yaml);
	}

	private string Serialize<T>(T obj)
	{
		try
		{
			return serializer.Serialize(obj);
		}
		catch (Exception e)
		{
			throw new Exception($"Failed to serialize yaml for file: {Path()}", e);
		}
	}

	private T Deserialize<T>(string yaml)
	{
		try
		{
			return deserializer.Deserialize<T>(yaml);
		}
		catch (Exception e)
		{
			throw new Exception($"Failed to deserialize yaml file: {Path()}", e);
		}
	}
}
