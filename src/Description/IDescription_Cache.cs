namespace Moroshka.Cli;

public partial interface IDescription
{
	public sealed class Cache(IDescription description) : IDescription
	{
		private string _cache = string.Empty;

		public string Value()
		{
			if (!string.IsNullOrEmpty(_cache)) return _cache;
			_cache = description.Value();
			return _cache;
		}
	}
}
