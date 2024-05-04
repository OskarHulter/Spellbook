using ArcaneLibrary.Domain;
using ArcaneLibrary.Validators;
using FluentValidation.Results;

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


int a = 10, b = 0;
try
{
    Log.Debug("Dividing {A} by {B}", a, b);
    Console.WriteLine(a / b);
}
catch (Exception ex)
{
    Log.Error(ex, "Something went wrong");
}
finally
{
    await Log.CloseAndFlushAsync();
}