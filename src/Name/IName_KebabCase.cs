namespace Moroshka.Cli;

public partial interface IName
{
	public sealed class KebabCase(IName name, ISeparators separators) : IName
	{
		public KebabCase(IName name) : this(name, new Separators())
		{
		}

		public string Value() => ToKebabCase();

		private string ToKebabCase()
		{
			var source = name.Value();
			var sb = new System.Text.StringBuilder(source.Length + 10);
			var isPrevLower = false;
			var needsDash = false;

			foreach (var c in source)
			{
				if (separators.Separator(c))
				{
					needsDash = sb.Length > 0;
					continue;
				}

				var isUpper = char.IsUpper(c);
				if (isUpper && isPrevLower || needsDash && char.IsLetterOrDigit(c))
				{
					sb.Append('-');
					needsDash = false;
				}

				sb.Append(char.ToLower(c));
				isPrevLower = !isUpper;
			}

			return sb.ToString();
		}
	}
}
