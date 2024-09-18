using Microsoft.EntityFrameworkCore;
using Payroll.Application.InterfaceRepository;
using Payroll.Application.InterfaceService.Payroll;
using Payroll.Application.Services.Payroll;
using Payroll.Persistence.Data;
using Payroll.Persistence.Repository.Payroll;
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
var connectionSring = builder.Configuration.GetConnectionString("PayrollConnectionString");
builder.Services.AddDbContext<PayrollDBContext>(options =>
    options.UseSqlServer(connectionSring)
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddTransient<IEmployeePersonalService, EmployeePersonalService>();
builder.Services.AddTransient<IEmployeePersonalRepository,EmployeePersonalRepository>();

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
