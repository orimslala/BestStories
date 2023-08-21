using AutoMapper;
using Santander.CodingTest.Application.Interfaces;
using Santander.CodingTest.Application.Queries;
using Santander.CodingTest.Application.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(o => o.AddPolicy("beststories", 
                                        p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddSingleton(new MapperConfiguration(m => m.AddProfiles(new List<Profile>
{
    new Santander.CodingTest.Domain.MappingProfile()
})).CreateMapper());
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IDataProvider, HackerNews> ();
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetBestStoriesQuery>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("beststories");
app.UseAuthorization();

app.MapControllers();

app.Run();
