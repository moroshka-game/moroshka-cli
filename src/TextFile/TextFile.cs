namespace Moroshka.Cli;

public sealed class TextFile(IFile file) : ITextFile
{
	public TextFile(string path)
		: this(new File(path))
	{
	}

	public TextFile(string dir, string name)
		: this(new File(dir, name))
	{
	}

	public TextFile(string name, IDir dir)
		: this(new File(name, dir))
	{
	}

	public string Path() => file.Path();

	public bool Exists() => file.Exists();

	public string Read()
	{
		var path = Path();
		try
		{
			return System.IO.File.ReadAllText(path);
		}
		catch (Exception e)
		{
			throw new Exception($"Failed to read text file: {path}", e);
		}
	}

	public void Write(string content)
	{
		var path = Path();
		try
		{
			System.IO.File.WriteAllText(path, content);
		}
		catch (Exception e)
		{
			throw new Exception($"Failed to write text file: {path}", e);
		}
	}
}
