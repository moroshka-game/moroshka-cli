namespace Moroshka.Cli;

public partial interface ITextFile : IFile
{
	string Read();

	void Write(string content);
}
