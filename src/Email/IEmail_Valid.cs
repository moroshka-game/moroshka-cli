namespace Moroshka.Cli;

public partial interface IEmail
{
	public sealed class Valid(IEmail email) : IEmail
	{
		public string Value()
		{
			var value = email.Value();
			if (Validate(value)) return value;
			throw new Exception("Email does not match format (name@example.com)");
		}

		private static bool Validate(string value)
		{
			var emailRegex = Regex();
			return emailRegex.IsMatch(value);
		}
	}
}
