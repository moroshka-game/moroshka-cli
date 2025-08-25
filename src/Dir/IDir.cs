namespace Moroshka.Cli;

public partial interface IDir
{
	string Value();

	void Create();

	bool Exists();
}
