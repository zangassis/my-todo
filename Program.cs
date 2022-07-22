using MyTodo.Data;
using MyTodo.Models;
using MyTodo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<TodoDbContext>();
builder.Services.AddScoped<TodoService>();
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

app.MapGet("/find-all", (TodoService service) =>
{
    var todos = service.FindAll();
    return todos is not null ? Results.Ok(todos) : Results.NotFound();
});

app.MapPost("/create", (TodoService service, Todo entity) =>
{
    bool result = service.Create(entity);
    return result is true ? Results.Ok("Entity created successfully") : Results.BadRequest("Error saving entity");
});

app.Run();