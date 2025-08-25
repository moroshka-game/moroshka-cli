namespace Moroshka.Cli;

public sealed class Email(string value) : IEmail
{
	public string Value() => value;
}
