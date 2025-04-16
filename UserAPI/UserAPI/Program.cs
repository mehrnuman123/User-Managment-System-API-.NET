var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();

app.UseMiddleware<LoggingMiddleware>();
app.MapGet("/", () => "Hello World!");

app.Run();
