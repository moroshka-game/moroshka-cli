using Spectre.Console;

namespace Moroshka.Cli;

public partial interface IIndexes
{
	public sealed class Input(IModulesFile file, string defaultValue) : IIndexes
	{
		public Input(IModulesFile file) : this(
			file,
			new ProjectInfoFile().Data().Dependencies)
		{
		}

		public IReadOnlyList<int> Values()
		{
			new IModulesFile.Display(file).Print();
			var indexes = AskIndexes();
			return SelectValidIndexes(indexes);
		}

		private string[] AskIndexes()
		{
			var value = AnsiConsole.Ask("[yellow]Enter indexes with a space[/]", defaultValue);
			return value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		}

		private List<int> SelectValidIndexes(string[] indexes)
		{
			if (indexes.Length == 0) return [];
			var maxIndex = file.Read().Count - 1;
			var validIndexes = new HashSet<int>();
			var invalidIndexes = new HashSet<string>();

			foreach (var idx in indexes)
			{
				if (idx == "none") continue;
				if (!int.TryParse(idx, out var index) || index < 0 || index > maxIndex) invalidIndexes.Add(idx);
				else validIndexes.Add(index);
			}

			if (invalidIndexes.Count == 0) return validIndexes.ToList();
			var invalidIndexesString = string.Join(", ", invalidIndexes);
			AnsiConsole.MarkupLine($"[red]Invalid indexes: {invalidIndexesString}[/]");
			return validIndexes.ToList();
		}
	}
}
