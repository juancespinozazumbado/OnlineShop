using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuth.Api.contexts;
using RoleBasedAuth.Api.Models.Auth;
using Microsoft.EntityFrameworkCore.Design;
using RoleBasedAuth.Api.Dependencies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RoleBasedAuth.Api.Config;
using System.Text;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add EF Core
#if DEBUG
var connectionString = builder.Configuration.GetConnectionString("DebugConnectionString");

#else

 var connectionString = builder.Configuration.GetConnectionString("ProdConnectionString");

#endif
builder.Services.AddDbContext<RoleBaedDbContext>(options =>
  options.UseSqlServer(connectionString));

builder.Services.AddIdentity<User,IdentityRole>()
    .AddEntityFrameworkStores<RoleBaedDbContext>()
    //.AddUserManager<User>()
    //.AddRoleManager<IdentityRole>()
    .AddDefaultTokenProviders();

builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
var jwtOptions = builder.Configuration.GetSection("ApiSettings:JwtOptions");
//configure autentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    
})
    .AddJwtBearer( options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuer = true,
             ValidateAudience = true,
             ValidateLifetime = true,
             ValidateIssuerSigningKey = true,
             ValidIssuer = jwtOptions["Issuer"],
             ValidAudience = jwtOptions["Audience"],
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions["secret"]))
         };
     });

builder.Services.AddRepository();

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

builder.Services.AddAutneticatorServices();

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
