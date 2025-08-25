namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class Moroshka(IName name) : IName
	{
		public string Value() => $"moroshka.{name.Value()}";
	}
}
