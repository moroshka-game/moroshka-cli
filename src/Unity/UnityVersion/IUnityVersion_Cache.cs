namespace Moroshka.Cli;

public partial interface IUnityVersion
{
	public sealed class Cache(IUnityVersion version) : IUnityVersion
	{
		private string _cache = string.Empty;

		public string Value()
		{
			if (!string.IsNullOrEmpty(_cache)) return _cache;
			_cache = version.Value();
			return _cache;
		}
	}
}