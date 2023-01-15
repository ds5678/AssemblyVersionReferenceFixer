using AsmResolver.DotNet;

namespace AssemblyVersionReferenceFixer;

internal class Program
{
	static void Main(string[] args)
	{
		string filePath = args[0];
		ModuleDefinition module = ModuleDefinition.FromFile(filePath);
		foreach (AssemblyReference assemblyReference in module.AssemblyReferences)
		{
			string? name = assemblyReference.Name;
			if (name is not null && name.StartsWith("AssetRipper") && !name.StartsWith("AssetRipper.VersionUtilities"))
			{
				assemblyReference.Version = new Version(0, 3, 0, 4);
			}
		}
		module.Write(Path.GetFileName(filePath));
		Console.WriteLine("Done!");
	}
}
