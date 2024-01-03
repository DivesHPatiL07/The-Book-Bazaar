using EntityBase;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//var provider = builder.Services.BuildServiceProvider();
//var config = provider.GetRequiredService<IConfiguration>();
//builder.Services.AddDbContextPool<AppDbContext>(item => item.UseSqlServer(config.GetConnectionString("DB_Conn_String")));
//builder.Services.AddDbContext<AppDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DB_Conn_String")));

builder.Services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer("Server=LAPTOP-GSDBM2F1\\SQLEXPRESS; database=OnlineBookStore; trusted_connection=true;"));
//builder.Services.AddSingleton<JwtTokenHandler>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
