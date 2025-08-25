namespace Moroshka.Cli;

public partial interface IVersion
{
	public sealed class Valid(IVersion version) : IVersion
	{
		public string Value()
		{
			var value = version.Value();
			if (Validate(value)) return value;
			throw new Exception("Version does not match X.Y.Z (non-negative integers without leading zeros) format");
		}

		private static bool Validate(string value)
		{
			var parts = value.Split('.');
			if (parts.Length != 3) return false;

			foreach (var part in parts)
			{
				if (string.IsNullOrEmpty(part)) return false;
				if (part.Length > 1 && part[0] == '0') return false;
				if (!part.All(char.IsDigit)) return false;
			}

			return true;
		}
	}
}
