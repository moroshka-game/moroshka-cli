namespace Moroshka.Cli;

public sealed class ManifestFile(ITextFile templateFile, ITextFile outputFile) : IManifestFile
{
	public ManifestFile(IDir dir) : this(
		new TextFile(
			new File("manifest.json", new IDir.Templates())),
		new TextFile("manifest.json", dir))
	{
	}

	public void Create()
	{
		var content = templateFile.Read();
		outputFile.Write(content);
	}
}
