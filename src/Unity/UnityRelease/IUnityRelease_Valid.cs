namespace Moroshka.Cli;

public partial interface IUnityRelease
{
	public sealed class Valid(IUnityRelease release) : IUnityRelease
	{
		public string Value()
		{
			var value = release.Value();
			if (ValidateRelease(value)) return value;
			throw new Exception("Unity release does not match <update><release> (0b4 / 1a2 / 2f1 / 12b10) format");
		}

		private static bool ValidateRelease(string value)
		{
			var releaseRegex = Regex();
			return releaseRegex.IsMatch(value);
		}
	}
}