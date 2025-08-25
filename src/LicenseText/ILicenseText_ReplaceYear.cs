namespace Moroshka.Cli;

public partial interface ILicenseText
{
	public sealed class ReplaceYear(ILicenseText license) : ILicenseText
	{
		public string Value() => license.Value().Replace("<year>", DateTime.UtcNow.Year.ToString());
	}
}