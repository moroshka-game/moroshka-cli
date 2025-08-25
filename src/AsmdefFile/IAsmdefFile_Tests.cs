namespace Moroshka.Cli;

public partial interface IAsmdefFile
{
	public sealed class Tests(IAsmdefFile file) : IAsmdefFile
	{
		public Tests(IDir dir, IProjectInfo projectInfo)
			: this(new AsmdefFile(
				new IAsmdef.Test(projectInfo.Name()),
				new IDir.UpmTests(dir),
				$"{new IName.Test(
						new IName.DisplayName(projectInfo.Name()))
					.Value()}.asmdef"))
		{
		}

		public void Create() => file.Create();
	}
}
