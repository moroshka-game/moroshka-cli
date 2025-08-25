namespace Moroshka.Cli;

public partial interface ILicenseText
{
	public sealed class ReplaceAuthor(ILicenseText license, IAuthor author) : ILicenseText
	{
		public string Value() => license.Value().Replace("<copyright holders>", $"{author.Name()} ({author.Email()})");
	}
}