namespace Moroshka.Cli;

public partial interface IAsmdef
{
	public sealed class Default(IAsmdef asmdef) : IAsmdef
	{
		public Default(IName name, IReferences references)
			: this(
				new Asmdef(
					new IName.DisplayName(name),
					new Platforms(),
					references))
		{
		}

		public string Name() => asmdef.Name();

		public string RootNamespace() => asmdef.RootNamespace();

		public IReadOnlyList<string> References() => asmdef.References();

		public IReadOnlyList<string> IncludePlatforms() => asmdef.IncludePlatforms();

		public IReadOnlyList<string> ExcludePlatforms() => asmdef.ExcludePlatforms();

		public bool AllowUnsafeCode() => asmdef.AllowUnsafeCode();

		public bool OverrideReferences() => asmdef.OverrideReferences();

		public IReadOnlyList<string> PrecompiledReferences() => asmdef.PrecompiledReferences();

		public bool AutoReferenced() => asmdef.AutoReferenced();

		public IReadOnlyList<string> DefineConstraints() => asmdef.DefineConstraints();

		public IReadOnlyList<VersionDefine> VersionDefines() => asmdef.VersionDefines();

		public bool NoEngineReferences() => asmdef.NoEngineReferences();
	}
}
