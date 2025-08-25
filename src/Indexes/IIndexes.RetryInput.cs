namespace Moroshka.Cli;

public partial interface IIndexes
{
	public sealed class RetryInput(IIndexes indexes) : IIndexes
	{
		public IReadOnlyList<int> Values()
		{
			while (true)
			{
				var value = indexes.Values();
				if (value.Count > 0) return value;
			}
		}
	}
}
