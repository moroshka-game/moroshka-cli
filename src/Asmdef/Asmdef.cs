namespace Moroshka.Cli;

public sealed class Asmdef(IName name, IPlatforms platforms, IReferences references) : IAsmdef
{
	public string Name() => name.Value();

	public string RootNamespace() => name.Value();

	public IReadOnlyList<string> References() => references.Values();

	public IReadOnlyList<string> IncludePlatforms() => platforms.Values();

	public IReadOnlyList<string> ExcludePlatforms() => [];

	public bool AllowUnsafeCode() => false;

	public bool OverrideReferences() => false;

	public IReadOnlyList<string> PrecompiledReferences() => [];

	public bool AutoReferenced() => true;

	public IReadOnlyList<string> DefineConstraints() => [];

	public IReadOnlyList<IAsmdef.VersionDefine> VersionDefines() => [];

	public bool NoEngineReferences() => false;
}
