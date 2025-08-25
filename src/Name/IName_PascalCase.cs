using System.Text;

namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class PascalCase(IName name, ISeparators separators) : IName
	{
		public PascalCase(IName name) : this(name, new Separators())
		{
		}

		public string Value() => ToPascalCase();

		private string ToPascalCase()
		{
			var source = name.Value();
			var builder = new StringBuilder(source.Length);
			var upperNext = true;

			foreach (var c in source)
			{
				if (separators.Separator(c))
				{
					upperNext = true;
					continue;
				}

				if (upperNext)
				{
					builder.Append(char.ToUpper(c));
					upperNext = false;
				}
				else
				{
					builder.Append(char.ToLower(c));
				}
			}

			return builder.ToString();
		}
	}
}
