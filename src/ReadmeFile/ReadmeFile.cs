namespace Moroshka.Cli;

public sealed class ReadmeFile(ITextFile templateFile, ITextFile outputFile) : IReadmeFile
{
	public ReadmeFile(IDir dir, IProjectInfo projectInfo) : this(
		new ITextFile.ReplaceName(
			new ITextFile.ReplaceDescription(
				new TextFile(
					new File("README.md",
						new IDir.Templates())),
				projectInfo.Description()),
			projectInfo.Name()),
		new TextFile("README.md", dir))
	{
	}

	public void Create()
	{
		var content = templateFile.Read();
		outputFile.Write(content);
	}
}
