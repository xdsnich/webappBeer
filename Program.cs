using Microsoft.EntityFrameworkCore;
using WebAppbotbeer.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("AllowAll");

app.UseStaticFiles();

app.UseRouting();

app.UseDefaultFiles();
app.UseCors("AllowAllOrigins");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();