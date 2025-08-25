using System.Text.RegularExpressions;

namespace Moroshka.Cli;

public partial interface IUnityVersion
{
	[GeneratedRegex(@"^\d{4}\.\d+$")]
	private static partial Regex RegexVersion();
}
