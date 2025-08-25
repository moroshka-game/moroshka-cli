namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class UpmProject(IName name) : IName
	{
		public string Value() => new KebabCase(new Moroshka(name)).Value();
	}
}
