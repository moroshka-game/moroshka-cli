namespace Moroshka.Cli;

public sealed class ChangeLogFile(ITextFile templateFile, ITextFile outputFile) : IChangeLogFile
{
	public ChangeLogFile(IDir dir) : this(
		new TextFile(
			new File("changelog.md",
				new IDir.Templates())),
		new TextFile("CHANGELOG.md", dir))
	{
	}

	public void Create()
	{
		var content = templateFile.Read();
		var today = DateTime.UtcNow.ToString("yyyy-MM-dd");
		content = content.Replace("{date}", today);
		outputFile.Write(content);
	}
}
