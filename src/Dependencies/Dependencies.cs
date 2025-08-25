namespace Moroshka.Cli;

public sealed class Dependencies(IReadOnlyList<IModule> modules) : IDependencies
{
	public Dependencies(IProjectData data) : this(
		new IModulesFile.Where(data,
				new IModulesFile.Cache(
					new ModulesFile(
						new TextFile(
							new File("modules.yaml",
								new IDir.Templates())))))
			.Read())
	{
	}

	public IReadOnlyList<IModule> Modules() => modules;
}
