namespace Moroshka.Cli;

public partial interface ILicense
{
	public sealed class Cache(ILicense license) : ILicense
	{
		private string _cache = string.Empty;

		public string Value()
		{
			if (!string.IsNullOrEmpty(_cache)) return _cache;
			_cache = license.Value();
			return _cache;
		}
	}
}
