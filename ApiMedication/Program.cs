using ApiMedication.Dto.Mappings;
using ApiMedication.MedicationData;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ApiMedication.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var map = new MapperConfiguration(mc =>
{  
    mc.AddProfile(new MedicationMapping());
});

builder.Services.AddSingleton(map.CreateMapper());

builder.Services.AddDbContextPool<MedicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MedicationConnectionDb")));

builder.Services.AddScoped<IMedicationData, MedicationData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ExceptionHandler();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
