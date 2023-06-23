
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Student_Management_System.Models;
using Student_Management_System.Models.Interface;
using Student_Management_System.Models.Repository;
using Student_Management_System.Services.AutoMapperProfile;
using Student_Management_System.Services.Interafce;
using Student_Management_System.Services.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigureJwtAuthService(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    //option.SwaggerDoc("v1", new OpenApiInfo { Title = "JWTDemo", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter jwt access token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});
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
builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<IStudentService,StudentService>();
builder.Services.AddScoped<IAdminService,AdminService>();
builder.Services.AddScoped<IAdminRepository,AdminRepository>();
builder.Services.AddScoped<IRTokenRepository,RTokenRepository>();
builder.Services.AddScoped<IRTokenService,RTokenService>();
builder.Services.AddScoped<IAttendanceRepository,AttendanceRepository>();


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

void ConfigureJwtAuthService(IServiceCollection services)
{
    var config = builder.Configuration.GetSection("JWTConfig");
    var symmetricKeyAsBase64 = config["SecretKey"];
    var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
    var signingKey = new SymmetricSecurityKey(keyByteArray);

    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = config["Issuer"],
            ValidateAudience = false,
            ValidAudience = config["Aud"],
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = signingKey,
            ClockSkew = TimeSpan.Zero
        };
    });
}
