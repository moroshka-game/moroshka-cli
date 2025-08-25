namespace Moroshka.Cli;

public partial interface IAsmdefFile
{
	public sealed class Default(IAsmdefFile file) : IAsmdefFile
	{
		public Default(IDir dir, IProjectInfo projectInfo)
			: this(
				new AsmdefFile(
					new IAsmdef.Default(projectInfo.Name(),
						new References(projectInfo.Dependencies())),
					new IDir.UpmRuntime(dir),
					$"{new IName.DisplayName(projectInfo.Name()).Value()}.asmdef"))
		{
		}

		public void Create() => file.Create();
	}
}
