namespace Moroshka.Cli;

public partial interface IEmail
{
	public sealed class Cache(IEmail email) : IEmail
	{
		private string _cache = string.Empty;

		public string Value()
		{
			if (!string.IsNullOrEmpty(_cache)) return _cache;
			_cache = email.Value();
			return _cache;
		}
	}
}
