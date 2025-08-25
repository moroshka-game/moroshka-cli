namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class BenchmarkProject(string dir, string name) : IDir
	{
		public BenchmarkProject(IDir dir, IProjectInfo projectInfo) : this(
			dir.Value(),
			new IName.KebabCase(
				new IName.Moroshka(projectInfo.Name()))
				.Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, $"{name}-benchmark");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
