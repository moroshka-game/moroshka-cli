namespace Moroshka.Cli;

public partial interface IModulesFile
{
	public sealed class Cache(IModulesFile modulesFile) : IModulesFile
	{
		private IReadOnlyList<IModule> _cache = [];

		public IReadOnlyList<IModule> Read()
		{
			if (_cache.Any()) return _cache;
			_cache = modulesFile.Read();
			return _cache;
		}
	}
}
