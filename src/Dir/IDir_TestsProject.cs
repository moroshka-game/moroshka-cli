namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class TestsProject(string dir, string name) : IDir
	{
		public TestsProject(IDir dir, IProjectInfo projectInfo) : this(
			dir.Value(),
			new IName.KebabCase(
				new IName.Moroshka(projectInfo.Name()))
				.Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, $"{name}-tests");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
