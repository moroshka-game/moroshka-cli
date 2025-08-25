namespace Moroshka.Cli;

public partial interface ITextFile
{
	public sealed class ReplaceDescription(ITextFile file, IDescription description) : ITextFile
	{
		public string Path() => file.Path();

		public bool Exists() => file.Exists();

		public string Read()
		{
			var content = file.Read();
			return content.Replace("{description}", description.Value());
		}

		public void Write(string content) => file.Write(content);
	}
}
