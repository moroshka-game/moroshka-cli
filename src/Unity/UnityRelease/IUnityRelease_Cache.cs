namespace Moroshka.Cli;

public partial interface IUnityRelease
{
	public sealed class Cache(IUnityRelease release) : IUnityRelease
	{
		private string _cache = string.Empty;

		public string Value()
		{
			if (!string.IsNullOrEmpty(_cache)) return _cache;
			_cache = release.Value();
			return _cache;
		}
	}
}