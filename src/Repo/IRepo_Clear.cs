namespace Moroshka.Cli;

public partial interface IRepo
{
	public sealed class Clear(IRepo repo) : IRepo
	{
		public string Path() => repo.Path();

		public string Url() => repo.Url();

		public bool Clone()
		{
			var path = repo.Path();
			if (Directory.Exists(path)) Directory.Delete(path, true);
			return repo.Clone();
		}
	}
}
