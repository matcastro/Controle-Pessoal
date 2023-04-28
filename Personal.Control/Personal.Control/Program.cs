using Microsoft.EntityFrameworkCore;
using Personal.Control.Configs;
using Personal.Control.Repositories.Contexts;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.GetSection(nameof(Config)).Get<Config>();

// Add services to the container.
builder.Services.Configure<Config>(builder.Configuration.GetSection(nameof(Config)));

var databaseServer= Environment.GetEnvironmentVariable("MYSQL_DATABASE_SERVER");
var databaseUser= Environment.GetEnvironmentVariable("MYSQL_DATABASE_USER");
var databasePassword = Environment.GetEnvironmentVariable("MYSQL_DATABASE_PASSWORD");
var connectionString = builder.Configuration.GetConnectionString("Control")!;
connectionString = string.Format(connectionString, databaseServer, databaseUser, databasePassword);

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
