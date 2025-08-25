namespace Moroshka.Cli;

public sealed class LicenseText(string value) : ILicenseText
{
	public LicenseText(ILicense license, IAuthor author) : this(
		new ILicenseText.ReplaceAuthor(
				new ILicenseText.ReplaceYear(
					new ILicenseText.Status(
						new ILicenseText.Url(license,
							new Url("https://spdx.org/licenses/{id}.txt")))),
				author)
			.Value())
	{
	}

	public string Value() => value;
}
