namespace Moroshka.Cli;

public sealed class ProjectVersionFile(IProjectInfo projectInfo, ITextFile file) : IProjectVersionFile
{
	public ProjectVersionFile(IDir dir, IProjectInfo projectInfo)
		: this(
			projectInfo,
			new TextFile("ProjectVersion.txt", dir))
	{
	}

	public void Create()
	{
		var unity = projectInfo.Unity();
		file.Write($"m_EditorVersion: {unity.Version()}.{unity.Release()}");
	}
}
