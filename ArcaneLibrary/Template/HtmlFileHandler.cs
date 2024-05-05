using ArcaneLibrary.Template;
using HtmlAgilityPack;

namespace Evoker.HtmlReader;

// Description: HAP - Load (From File)
// Website: https://html-agility-pack.net/
// Run: https://dotnetfiddle.net/EsvZyg

// @nuget: HtmlAgilityPack

public class HtmlFileHandler
{
    public HtmlFileHandler(SectionPlaceholder section)
    {
        var dir = Directory.GetCurrentDirectory();

        #region example

        var path = @$"${dir}/{section}.html";

        var doc = new HtmlDocument();
        doc.Load(path);

        // var node = doc.DocumentNode.SelectSingleNode("//body");

        var node = doc.DocumentNode.ChildNodes;
        Console.WriteLine(node);

        #endregion
    }
}