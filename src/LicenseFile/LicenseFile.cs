namespace Moroshka.Cli;

public sealed class LicenseFile(ILicenseText licenseText, ITextFile file) : ILicenseFile
{
	public LicenseFile(IDir dir, IProjectInfo projectInfo)
		: this(
			new LicenseText(projectInfo.License(), projectInfo.Author()),
			new TextFile("LICENSE.md", dir))
	{
	}

	public void Create() => file.Write(licenseText.Value());
}
