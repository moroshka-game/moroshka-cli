namespace Moroshka.Cli;

[Serializable]
public sealed class AuthorData : IAuthorData
{
	public string Name { get; init; } = "Name";

	public string Email { get; init; } = "email@example.com";
}
