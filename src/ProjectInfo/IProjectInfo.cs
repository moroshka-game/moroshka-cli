namespace Moroshka.Cli;

public interface IProjectInfo
{
	IName Name();

	IVersion Version();

	IDescription Description();

	IAuthor Author();

	IUnity Unity();

	ILicense License();

	IDependencies Dependencies();
}
