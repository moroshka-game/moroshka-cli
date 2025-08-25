using System.Text;

namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class DisplayName(IName name) : IName
	{
		public string Value() => $"Moroshka.{new PascalCase(name).Value()}";
	}
}
