using _1._API.Mapper;
using _2._Domain;
using _3._Data;
using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyeccion dependencias
builder.Services.AddScoped<IStudentData, StudentSQLData>();
builder.Services.AddScoped<IStudentDomain, StudentDomain>();
    
//Pomelo MySQL Conexion
var connectionString = builder.Configuration.GetConnectionString("StudyMentorDB");
builder.Services.AddDbContext<StudyMentorDB>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });


//AutoMapper
builder.Services.AddAutoMapper(
    typeof(ModelToAPI),
    typeof(APIToModel)
);



var app = builder.Build();

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<StudyMentorDB>())
{
    context.Database.EnsureCreated();
}

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