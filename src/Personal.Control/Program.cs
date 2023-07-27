using Personal.Control.Mappings;
using Personal.Control.Middlewares;
using Personal.Control.Repositories.DI;
using Personal.Control.Services.DI;
using Personal.Control.Utils.Configs;
using Personal.Control.Utils.Helpers;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration.GetSection(nameof(Config)).Get<Config>();
ConfigurationHelper.Initialize(configuration);

// Add services to the container.
builder.Services.Configure<Config>(builder.Configuration.GetSection(nameof(Config)));

builder.Services.AddAutoMapper(typeof(UserMapperConfig));
builder.Services.AddRepositories(builder.Configuration);
builder.Services.AddServices();

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

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
