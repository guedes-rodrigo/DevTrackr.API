using DevTrackr.API.Persistence;
using DevTrackr.API.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddSingleton<DevTrackrContext>();
var connectionString = builder.Configuration.GetConnectionString("DevTrackrCs");

builder.Services.AddDbContext<DevTrackrContext>(o => o.UseSqlServer(connectionString));

//builder.Services.AddDbContext<DevTrackrContext>(o => o.UseInMemoryDatabase("DevTrackr"));

//builder.Services.AddSingleton<DevTrackrContext>();

builder.Services.AddScoped<IPackageRepository, PackageRepository>();

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
