using Microsoft.EntityFrameworkCore;
using todo_api_minimal.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoList"));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.MapGet("api/todo", async (TodoContext context) => await context.TodoItem.ToListAsync());

//app.MapGet("api/todo",  (TodoContext context) => {
//    return context.TodoItem.ToList();
//});

app.MapGet("api/todo", async (TodoContext context) => {
    return await context.TodoItem.ToListAsync();
});


app.MapGet("/todo/{id}", async (TodoContext context, int id) => await context.TodoItem.FirstOrDefaultAsync(x => x.Id == id));

app.MapPost("api/todo", async (TodoContext context, TodoItem item) =>
{
    context.TodoItem.Add(item);
    await context.SaveChangesAsync();
});

app.MapPut("api/todo/{id}", async (TodoContext context, TodoItem todoItem) =>
{
    context.TodoItem.Update(todoItem);
    await context.SaveChangesAsync();
});

app.MapDelete("api/todo/{id}", async (TodoContext context, int id) =>
{
    var existItem = await context.TodoItem.FirstOrDefaultAsync(x => x.Id == id);
    if (existItem == null)
    {
        throw new ApplicationException("No encontrado");
    }

    context.TodoItem.Remove(existItem);
    await context.SaveChangesAsync();
});


app.Run();
