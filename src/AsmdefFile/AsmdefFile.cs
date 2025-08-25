using System.Text.Json;
namespace Moroshka.Cli;

public sealed class AsmdefFile(IAsmdef asmdef, IJsonFile jsonFile) : IAsmdefFile
{
	public AsmdefFile(IAsmdef asmdef, IDir dir, string name)
		: this(asmdef, new JsonFile(dir, name, new JsonSerializerOptions { WriteIndented = true }))
	{
	}

	public void Create()
	{
		jsonFile.Write(new AsmdefDto
		{
			name = asmdef.Name(),
			rootNamespace = asmdef.RootNamespace(),
			references = asmdef.References().ToArray(),
			includePlatforms = asmdef.IncludePlatforms().ToArray(),
			excludePlatforms = asmdef.ExcludePlatforms().ToArray(),
			allowUnsafeCode = asmdef.AllowUnsafeCode(),
			overrideReferences = asmdef.OverrideReferences(),
			precompiledReferences = asmdef.PrecompiledReferences().ToArray(),
			autoReferenced = asmdef.AutoReferenced(),
			defineConstraints = asmdef.DefineConstraints().ToArray(),
			versionDefines = asmdef.VersionDefines().Select(v => new VersionDefineDto
			{
				name = v.name,
				define = v.define,
				expression = v.expression
			}).ToArray(),
			noEngineReferences = asmdef.NoEngineReferences()
		});
	}

	private sealed class AsmdefDto
	{
		public string name { get; init; } = string.Empty;
		public string rootNamespace { get; init; } = string.Empty;
		public string[] references { get; init; } = [];
		public string[] includePlatforms { get; init; } = [];
		public string[] excludePlatforms { get; init; } = [];
		public bool allowUnsafeCode { get; init; }
		public bool overrideReferences { get; init; }
		public string[] precompiledReferences { get; init; } = [];
		public bool autoReferenced { get; init; }
		public string[] defineConstraints { get; init; } = [];
		public VersionDefineDto[] versionDefines { get; init; } = [];
		public bool noEngineReferences { get; init; }
	}

	private sealed class VersionDefineDto
	{
		public string name { get; init; } = string.Empty;
		public string define { get; init; } = string.Empty;
		public string expression { get; init; } = string.Empty;
	}
}
