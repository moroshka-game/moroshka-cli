namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class Editor(IName name) : IName
	{
		public string Value() => $"{name.Value()}.Editor";
	}
}
