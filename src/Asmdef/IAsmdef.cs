namespace Moroshka.Cli;

public partial interface IAsmdef
{
	string Name();

	string RootNamespace();

	IReadOnlyList<string> References();

	IReadOnlyList<string> IncludePlatforms();

	IReadOnlyList<string> ExcludePlatforms();

	bool AllowUnsafeCode();

	bool OverrideReferences();

	IReadOnlyList<string> PrecompiledReferences();

	bool AutoReferenced();

	IReadOnlyList<string> DefineConstraints();

	IReadOnlyList<VersionDefine> VersionDefines();

	bool NoEngineReferences();

	public sealed record VersionDefine(string name, string define, string expression);
}
