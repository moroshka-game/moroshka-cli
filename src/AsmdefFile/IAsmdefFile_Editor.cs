namespace Moroshka.Cli;

public partial interface IAsmdefFile
{
	public sealed class Editor(IAsmdefFile file) : IAsmdefFile
	{
		public Editor(IDir dir, IProjectInfo projectInfo)
			: this(
				new AsmdefFile(
					new IAsmdef.Editor(projectInfo.Name()),
					new IDir.UpmEditor(dir),
					$"{new IName.Editor(new IName.DisplayName(projectInfo.Name())).Value()}.asmdef"))
		{
		}

		public void Create() => file.Create();
	}
}
