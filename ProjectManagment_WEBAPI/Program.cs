using Microsoft.EntityFrameworkCore;
using ProjectManagment_WEBAPI.Models;
using ProjectManagment_WEBAPI.Repository;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<Project_ManagmentContext>(options => options.UseSqlServer(connection));
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

builder.Services.AddCors();

var app = builder.Build();

// ����������� CORS
app.UseCors(builder => builder.AllowAnyOrigin());


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllers();
app.MapDefaultControllerRoute();

app.MapGet("/", () => "Hello World!");

app.Run();
