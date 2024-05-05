// using Evoker;

using Evoker;

using var log = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
Log.Logger = log;
Log.Information("Global logger has been configured");

var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();

Log.Information($"{resources}");
SpellType spell = new("lumos", "shines a light");
SpellValidator v = new();

ValidationResult r = v.Validate(spell);

log.Information(r.Errors.ToString());

// var reader = new AssemblyTextFileReader(assembly);
//
// string text = await reader.ReadFileAsync(@"MyFile.txt");

var reader = new AssemblyTextFileReader(Assembly.GetEntryAssembly());
var dir = Directory.GetCurrentDirectory();
// string text = await reader.ReadFileAsync(@$"{dir}/test.html");

// HtmlHelpers h = new();

log.Information(reader.ToString() ?? "assembly not found");
log.Information(HtmlHelpers.GetHtml(null));


try
{
    Log.Debug("reading {dir} and {r}", dir, r);

    HtmlHelpers.SaveHtmlFile();
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    await Log.CloseAndFlushAsync();
}