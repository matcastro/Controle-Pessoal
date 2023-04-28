using Personal.Control.Configs;
using Personal.Control.Repositories.DI;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.GetSection(nameof(Config)).Get<Config>();

// Add services to the container.
builder.Services.Configure<Config>(builder.Configuration.GetSection(nameof(Config)));

builder.Services.AddRepositories(builder.Configuration);

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
