namespace Moroshka.Cli;

public sealed class File(string path) : IFile
{
	public File(string name, IDir dir)
		: this(name, dir.Value())
	{
	}

	public File(string name, string dir)
		: this(System.IO.Path.Combine(dir, name))
	{
	}

	public string Path() => path;

	public bool Exists() => System.IO.File.Exists(path);
}
