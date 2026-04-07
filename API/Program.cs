var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
// Other services...
builder.Services.AddScoped<RepositoryACL>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => "API ASP.NET Core 8.0 + SQL Server - Running!");

app.MapGet("/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }));

app.MapGet("/db/test", async () =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    try
    {
        using var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
        await connection.OpenAsync();
        return Results.Ok(new { 
            status = "connected", 
            server = connection.DataSource,
            database = connection.Database
        });
    }
    catch (Exception ex)
    {
        return Results.Problem($"Connection failed: {ex.Message}");
    }
});

app.Run();
