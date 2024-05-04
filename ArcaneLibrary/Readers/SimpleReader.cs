using System.Reflection;

namespace ArcaneLibrary.Readers;

public class SimpleReader
{
    public SimpleReader()
    {
        var n = typeof(SimpleReader).Namespace;
        var filename = "MyFile.txt";
        using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{n}.{filename}"))
        using (var sr = new StreamReader(s))
        {
            var text = sr.ReadToEnd();
        }

// OR
        var ns = this.GetType().Namespace;
        var fn = "MyFile.txt";
        using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{ns}.{fn}"))
        using (var sr = new StreamReader(s))
        {
            var text = sr.ReadToEnd();
        }
    }
}