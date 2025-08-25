namespace Moroshka.Cli;

public partial interface IRepo
{
	string Path();

	string Url();

	bool Clone();
}
