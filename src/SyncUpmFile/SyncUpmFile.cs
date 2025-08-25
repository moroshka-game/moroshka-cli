namespace Moroshka.Cli;

public sealed class SyncUpmFile(ITextFile templateFile, ITextFile outputFile) : ISyncUpmFile
{
	public SyncUpmFile(IDir dir) : this(
		new TextFile(
			new File("sync-upm.yaml", new IDir.Templates())),
		new TextFile("sync-upm.yaml", dir))
	{
	}

	public void Create()
	{
		var content = templateFile.Read();
		outputFile.Write(content);
	}
}
