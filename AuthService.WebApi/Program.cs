
using AuthService.Infrastructure.Configurations;
using AuthService.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controllers
builder.Services.AddControllers();
builder.Services.AddApplication();

// Cors
string MyAllowSpecificOrigins = "AllowAnyOrigin";
builder.Services.ConfigureCors(MyAllowSpecificOrigins);

// Inyeccion de dependencias
// builder.Services.LoadRepositories();
// builder.Services.LoadServices();


builder.Services.ConfigureContext(builder.Configuration.GetConnectionString("DbAsaAuth") ?? "");

// Jasper Reports Config
// builder.Services.Configure<JasperConfig>(builder.Configuration.GetSection("JasperSettings"));

// Endpoints
builder.Services.AddEndpointsApiExplorer();

// Swagger Config
builder.Services.ConfigureSwagger();

// Auth Config
builder.Services.ConfigureAuth(builder);


// Configure the HTTP request pipeline.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();