namespace Moroshka.Cli;

public partial interface IUrl
{
	public sealed class Cache(IUrl url) : IUrl
	{
		private string _cache = string.Empty;

		public string Value()
		{
			if (string.IsNullOrWhiteSpace(_cache)) _cache = url.Value();
			return _cache;
		}
	}
}
