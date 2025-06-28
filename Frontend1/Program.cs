var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddCors();
app.MapGet("/", () => "Hello World!");

app.Run();