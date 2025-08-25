namespace Moroshka.Cli;

public class ProjectInfo(
	IName name,
	IVersion version,
	IDescription description,
	IAuthor author,
	IUnity unity,
	ILicense license,
	IDependencies dependencies) : IProjectInfo
{
	public ProjectInfo(IProjectData data) : this(
		new Name(),
		new Version(data),
		new Description(data),
		new Author(data),
		new Unity(data),
		new License(data),
		new Dependencies(data))
	{
	}

	public ProjectInfo() : this(new ProjectInfoFile().Data())
	{
	}

	public IName Name() => name;

	public IVersion Version() => version;

	public IDescription Description() => description;

	public IAuthor Author() => author;

	public IUnity Unity() => unity;

	public ILicense License() => license;

	public IDependencies Dependencies() => dependencies;
}
