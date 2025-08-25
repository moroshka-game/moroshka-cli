namespace Moroshka.Cli;

public partial interface IModulesFile
{
	public sealed class Where(IModulesFile modulesFile, IIndexes indexes) : IModulesFile
	{
		public Where(IProjectData data, IModulesFile modulesFile) : this(
			modulesFile,
			new IDependencies.InputDisplay(
				new IIndexes.Input(modulesFile, data.Dependencies)))
		{
		}

		public IReadOnlyList<IModule> Read()
		{
			var modules = modulesFile.Read();
			var indexesList = indexes.Values();
			return indexesList.Select(index => modules[index]).ToList();
		}
	}
}
