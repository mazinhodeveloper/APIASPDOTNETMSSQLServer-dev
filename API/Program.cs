// Program.cs
using APIASPDOTNETMSSQLServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// MVC with Razor
builder.Services.AddControllersWithViews()
       .AddRazorRuntimeCompilation();

// Swagger for APIs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency injection
builder.Services.AddScoped<RepositoryACL>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = "swagger"; // http://localhost:8080/swagger
    });
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

// Map API controllers with /api prefix
app.MapControllers(); // Your ACLController with [Route("api/acl")]

// Map Razor pages / MVC routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Optional minimal API endpoints
app.MapGet("/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }));

app.MapGet("/db/test", async (IConfiguration config) =>
{
    var connectionString = config.GetConnectionString("DefaultConnection");
    await using var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
    try
    {
        await connection.OpenAsync();
        return Results.Ok(new
        {
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