using ResTIConnect.Persistence.Context;
using ResTIConnect.Persistence;
using ResTIConnect.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigurePersistenceApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

CreateDatabase(app);

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();


static void CreateDatabase(WebApplication app)
{
    var serviceScope = app.Services.CreateScope();
    var dataContext = serviceScope.ServiceProvider.GetService<AppDbContext>();
    dataContext?.Database.EnsureCreated();
}