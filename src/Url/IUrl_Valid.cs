namespace Moroshka.Cli;

public partial interface IUrl
{
	public sealed class Valid(IUrl url) : IUrl
	{
		public string Value()
		{
			var value = url.Value();
			if (Validate(value)) return value;
			throw new Exception("Url does not match HTTP/HTTPS format");
		}

		private static bool Validate(string value)
		{
			if (!Uri.TryCreate(value, UriKind.Absolute, out var uriResult)) return false;
			return uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps;
		}
	}
}
