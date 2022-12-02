using Microsoft.EntityFrameworkCore;
using ProjectManagment_WEBAPI.Models;
using ProjectManagment_WEBAPI.Repository;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);

// получаем строку подключения из файла конфигурации
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// добавляем контекст ApplicationContext в качестве сервиса в приложение
builder.Services.AddDbContext<Project_ManagmentContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Project}");
app.MapDefaultControllerRoute();

app.MapControllers();

app.Run();
