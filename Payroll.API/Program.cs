using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Payroll.Application.InterfaceRepository;
using Payroll.Application.InterfaceRepository.Setup;
using Payroll.Application.InterfaceService.Payroll;
using Payroll.Application.InterfaceService.Setup;
using Payroll.Application.Services.Payroll;
using Payroll.Application.Services.Setup;
using Payroll.Application.Users.Commands;
using Payroll.Application.Users.Query;
using Payroll.Persistence.Data;
using Payroll.Persistence.Repository.Payroll;
using Payroll.Persistence.Repository.Setup;
using System.Reflection;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5195); // HTTP port
    serverOptions.ListenAnyIP(7051, listenOptions =>
    {
        listenOptions.UseHttps(); // Enable HTTPS
    });
});

builder.Services.AddControllers();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(typeof(RegisterUserCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(GetUserListQueryHandler).Assembly);

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var connectionSring = builder.Configuration.GetConnectionString("PayrollConnectionString");
builder.Services.AddDbContext<PayrollDBContext>(options =>
    options.UseSqlServer(connectionSring)
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<IEmployeePersonalService, EmployeePersonalService>();
builder.Services.AddTransient<IEmployeePersonalRepository, EmployeePersonalRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//register for Redis
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "UserCache_";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
