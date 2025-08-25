namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class Cache(IName name) : IName
	{
		private string _cache = string.Empty;

		public string Value()
		{
			if (!string.IsNullOrEmpty(_cache)) return _cache;
			_cache = name.Value();
			return _cache;
		}
	}
}
