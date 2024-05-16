using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Api.contexts;
using RoleBasedAuth.Api.Models.Auth;
using Microsoft.EntityFrameworkCore.Design;
using RoleBasedAuth.Api.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add EF Core
var connectionString = builder.Configuration.GetConnectionString("Local-docker");
builder.Services.AddDbContext<RoleBaedDbContext>(options =>
  options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<RoleBaedDbContext>()
    //.AddUserManager<User>()
    //.AddRoleManager<IdentityRole>()
    .AddDefaultTokenProviders();

builder.Services.AddRepository();

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

    MigrationService.DataBaseMigrationInitialization(app);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
