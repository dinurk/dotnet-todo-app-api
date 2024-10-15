using TasksApi.Models;
using TasksApi.DAL;
using TasksApi.Services;
using TasksApi.DTO.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.AddNpgsqlDbContext<AppDbContext>("myconnection");

builder.Services.AddScoped<TodoTaskRepository>();
builder.Services.AddScoped<TodoTaskService>();

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

builder.Services.AddAutoMapper(
    typeof(UserMappingProfile)
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
