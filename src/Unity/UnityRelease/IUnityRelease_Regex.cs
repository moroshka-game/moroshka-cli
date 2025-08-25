using System.Text.RegularExpressions;

namespace Moroshka.Cli;

public partial interface IUnityRelease
{
	[GeneratedRegex(@"^\d+[abf]\d+$")]
	private static partial Regex Regex();
}
