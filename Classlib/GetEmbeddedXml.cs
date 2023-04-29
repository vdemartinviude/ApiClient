namespace Classlib;

using System.IO;
using System.Reflection;
public static class GetEmbeddedXmlFromResource {
    public static string GetEmbeddedXmlContent(string resourceName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceStream = assembly.GetManifestResourceStream(resourceName);

        using (var reader = new StreamReader(resourceStream!))
        {
            return reader.ReadToEnd();
        }
    }
}