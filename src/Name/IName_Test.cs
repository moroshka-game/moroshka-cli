namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class Test(IName name) : IName
	{
		public string Value() => $"{name.Value()}.Test";
	}
}
