namespace Moroshka.Cli;

public partial interface IUnityVersion
{
	public sealed class Valid(IUnityVersion version) : IUnityVersion
	{
		public string Value()
		{
			var value = version.Value();
			if (ValidateVersion(value)) return value;
			throw new Exception("Unity version does not match ####.# format");
		}

		private static bool ValidateVersion(string value)
		{
			var versionRegex = RegexVersion();
			return versionRegex.IsMatch(value);
		}
	}
}