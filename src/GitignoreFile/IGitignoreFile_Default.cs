namespace Moroshka.Cli;

public partial interface IGitignoreFile
{
	public sealed class Default(IGitignoreFile file) : IGitignoreFile
	{
		public Default(IDir targetDir)
			: this(
				new GitignoreFile(
					new TextFile(
						new File("gitignore.txt",
							new IDir.Templates())),
					new TextFile(".gitignore", targetDir)))
		{
		}

		public void Create() => file.Create();
	}
}
