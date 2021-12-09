using Microsoft.EntityFrameworkCore;
using TR.MusicLibrary.DL;
using TR.MusicLibrary.DL.Interfaces;
using TR.MusicLibrary.Interfaces;
using TR.MusicLibrary.Services;
using TR.MusicLibrary.Services.Interfaces;
using TR.MusicLibrary.SL.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var commentsPath = Path.Combine(System.AppContext.BaseDirectory, "TR.MusicLibrary.xml");
    c.IncludeXmlComments(commentsPath);
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<TR.MusicLibrary.DL.DbContext>(o => o.UseInMemoryDatabase("MusicLibrary"));

builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
