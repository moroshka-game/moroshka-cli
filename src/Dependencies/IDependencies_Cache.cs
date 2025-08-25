namespace Moroshka.Cli;

public partial interface IDependencies
{
	public sealed class Cache(IDependencies dependencies) : IDependencies
	{
		private IReadOnlyList<IModule> _cache = [];

		public IReadOnlyList<IModule> Modules()
		{
			if (_cache.Any()) return _cache;
			_cache = dependencies.Modules();
			return _cache;
		}
	}
}
