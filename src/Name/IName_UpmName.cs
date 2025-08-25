namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class UpmName(IName name) : IName
	{
		public string Value() => $"com.moroshka.{new KebabCase(name).Value()}";
	}
}