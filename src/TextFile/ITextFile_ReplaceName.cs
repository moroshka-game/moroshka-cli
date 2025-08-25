namespace Moroshka.Cli;

public partial interface ITextFile
{
	public sealed class ReplaceName(ITextFile file, IName name) : ITextFile
	{
		public string Path() => file.Path();

		public bool Exists() => file.Exists();

		public string Read()
		{
			var content = file.Read();
			return content.Replace("{name}", new IName.DisplayName(name).Value());
		}

		public void Write(string content) => file.Write(content);
	}
}
