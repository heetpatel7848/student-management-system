
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Student_Management_System.Models;
using Student_Management_System.Models.Interface;
using Student_Management_System.Models.Repository;
using Student_Management_System.Services.AutoMapperProfile;
using Student_Management_System.Services.Interafce;
using Student_Management_System.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddAutoMapper(typeof(MapperProfile));



builder.Services.AddDbContext<StudentSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SMSConnStr"));
});

#region Dependency Injection
builder.Services.AddScoped<ITeacherService,TeacherService>();
builder.Services.AddScoped<ITeacherRepository,TeacherRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();
