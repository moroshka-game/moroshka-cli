using System.Text.Json;

namespace Moroshka.Cli;

public sealed class JsonFile(ITextFile textFile, JsonSerializerOptions options) : IJsonFile
{
	public JsonFile(IFile file, JsonSerializerOptions options) : this(new TextFile(file), options)
	{
	}

	public JsonFile(string path, JsonSerializerOptions options) : this(new TextFile(path), options)
	{
	}

	public JsonFile(string dir, string name, JsonSerializerOptions options) : this(new TextFile(dir, name), options)
	{
	}

	public JsonFile(IDir dir, string name, JsonSerializerOptions options) : this(new TextFile(name, dir), options)
	{
	}

	public T Read<T>()
	{
		var json = textFile.Read();
		return Deserialize<T>(json);
	}

	public void Write<T>(T obj)
	{
		var json = Serialize(obj);
		textFile.Write(json);
	}

	private string Serialize<T>(T obj)
	{
		try
		{
			return JsonSerializer.Serialize(obj, options);
		}
		catch (Exception e)
		{
			throw new Exception($"Failed to serialize json for file: {textFile.Path()}", e);
		}
	}

	private T Deserialize<T>(string json)
	{
		try
		{
			return JsonSerializer.Deserialize<T>(json, options) ??
			       throw new Exception($"Failed to deserialize json file: {textFile.Path()}");
		}
		catch (Exception e)
		{
			throw new Exception($"Failed to deserialize json file: {textFile.Path()}", e);
		}
	}
}
