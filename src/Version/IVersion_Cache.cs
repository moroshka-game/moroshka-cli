namespace Moroshka.Cli;

public partial interface IVersion
{
	public sealed class Cache(IVersion version) : IVersion
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
