using System.Reflection;

namespace ArcaneLibrary.Readers;

public class AssemblyTextFileReader(Assembly? assembly)
{
    private readonly Assembly _assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));

    public async Task<string> ReadFileAsync(string fileName)
    {
        var resourceName = _assembly.GetManifestResourceName(fileName);
        await using var stream = _assembly.GetManifestResourceStream(resourceName);
        if (stream == null) throw new InvalidOperationException();

        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }
}

public static class AssemblyExtensions
{
    public static string GetManifestResourceName(this Assembly assembly, string fileName)
    {
        string? name = assembly.GetManifestResourceNames().SingleOrDefault(
            n => n.EndsWith(fileName, StringComparison.InvariantCultureIgnoreCase)
        );
        if (string.IsNullOrEmpty(name))
        {
            throw new FileNotFoundException($"Embedded file '{fileName}' could not be found in assembly '{assembly.FullName}'.", fileName);
        }

        return name;
    }
}
// To use the code above:
// var reader = new AssemblyTextFileReader(assembly);
//
// string text = await reader.ReadFileAsync(@"MyFile.txt");