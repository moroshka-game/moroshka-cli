namespace Moroshka.Cli;

public partial interface IDir
{
	public sealed class Unity(string dir, string name) : IDir
	{
		public Unity(IDir dir, IProjectInfo projectInfo) : this(
			dir.Value(),
			new IName.KebabCase(
				new IName.Moroshka(projectInfo.Name()))
				.Value())
		{
			Create();
		}

		public string Value() => Path.Combine(dir, $"{name}-unity");

		public void Create() => Directory.CreateDirectory(Value());

		public bool Exists() => Directory.Exists(Value());
	}
}
