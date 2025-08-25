using System.Net.Http.Headers;

namespace Moroshka.Cli;

public partial interface ILicenseText
{
	public sealed class Url(ILicense spdxId, IUrl url) : ILicenseText
	{
		public string Value()
		{
			var id = GetLicenseId();
			var resolvedUrl = ResolveUrlWithId(id);

			using var http = CreateHttpClient();
			try
			{
				return FetchText(http, resolvedUrl);
			}
			catch (Exception e)
			{
				throw new Exception($"Failed to download SPDX license text for '{id}' from {resolvedUrl}", e);
			}
		}

		private static HttpClient CreateHttpClient()
		{
			var http = new HttpClient();
			http.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("moroshka-cli", "1.0"));
			http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
			return http;
		}

		private static string FetchText(HttpClient http, string resolvedUrl)
		{
			using var response = http.GetAsync(resolvedUrl).GetAwaiter().GetResult();
			response.EnsureSuccessStatusCode();
			var body = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			return body.Trim() + Environment.NewLine;
		}

		private string GetLicenseId() => spdxId.Value();

		private string ResolveUrlWithId(string id)
		{
			var pattern = url.Value();
			return pattern.Contains("{id}") ? pattern.Replace("{id}", id) : pattern;
		}
	}
}
