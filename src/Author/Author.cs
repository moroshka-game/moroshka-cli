namespace Moroshka.Cli;

public sealed class Author(string name, string email) : IAuthor
{
	public Author(IProjectData data) : this(
		new IName.Cache(
				new IAuthor.InputName(data.Author.Name))
			.Value(),
		new IEmail.Cache(
				new IEmail.Retry(
					new IEmail.Valid(
						new IAuthor.InputEmail(data.Author.Email))))
			.Value())
	{
	}

	public string Name() => name;

	public string Email() => email;
}
