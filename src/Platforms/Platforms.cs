namespace Moroshka.Cli;

public sealed class Platforms(IReadOnlyList<string> platforms) : IPlatforms
{
	public Platforms() : this([])
	{
	}

	public IReadOnlyList<string> Values() => platforms;
}
