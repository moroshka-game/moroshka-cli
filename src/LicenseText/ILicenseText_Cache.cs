namespace Moroshka.Cli;

public partial interface ILicenseText
{
	public sealed class Cache(ILicenseText license) : ILicenseText
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