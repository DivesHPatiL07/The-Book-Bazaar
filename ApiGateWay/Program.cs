using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts)=>true));
});
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseCors("CORSPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.UseOcelot();
app.Run();
