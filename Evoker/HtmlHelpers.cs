namespace Evoker;

public static class HtmlHelpers
{
    public static string GetHtml(string? content)
    {
        var html =
            @"<!DOCTYPE html>
    <html>
    <body>
    	<h1>This is <b>bold</b> heading</h1>
    	<p>This is <u>underlined</u> paragraph</p>
    	<h2>This is <i>italic</i> heading</h2>
    </body>
    </html> ";

        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(content ?? html);
        return htmlDoc.ToString() ?? html;
    }

    public static void SaveHtmlFile()
    {
        var html =
            @"<!DOCTYPE html>
<html>
<body>
	<h1>This is <b>bold</b> heading</h1>
	<p>This is <u>underlined</u> paragraph</p>
	<h2>This is <i>italic</i> heading</h2>
</body>
</html> ";

        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);

        htmlDoc.Save("saved.html");
    }
}