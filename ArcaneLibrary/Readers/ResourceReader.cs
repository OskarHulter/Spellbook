using System.Reflection;

namespace ArcaneLibrary.Readers;

public class ResourceReader
{
    public static IEnumerable<string> FindEmbededResources<TAssembly>(Func<string, bool> predicate)
    {
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        return
            GetEmbededResourceNames<TAssembly>()
                .Where(predicate)
                .Select(name => ReadEmbededResource(typeof(TAssembly), name))
                .Where(x => !string.IsNullOrEmpty(x));
    }

    public static IEnumerable<string> GetEmbededResourceNames<TAssembly>()
    {
        var assembly = Assembly.GetAssembly(typeof(TAssembly));
        return assembly.GetManifestResourceNames();
    }

    public static string ReadEmbededResource<TAssembly, TNamespace>(string name)
    {
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
        return ReadEmbededResource(typeof(TAssembly), typeof(TNamespace), name);
    }

    public static string ReadEmbededResource(Type assemblyType, Type namespaceType, string name)
    {
        if (assemblyType == null) throw new ArgumentNullException(nameof(assemblyType));
        if (namespaceType == null) throw new ArgumentNullException(nameof(namespaceType));
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
        return ReadEmbededResource(assemblyType, $"{namespaceType.Namespace}.{name}");
    }

    public static string ReadEmbededResource(Type assemblyType, string name)
    {
        if (assemblyType == null) throw new ArgumentNullException(nameof(assemblyType));
        if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
        var assembly = Assembly.GetAssembly(assemblyType);
        using (var resourceStream = assembly.GetManifestResourceStream(name))
        {
            if (resourceStream == null) return null;
            using (var streamReader = new StreamReader(resourceStream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}