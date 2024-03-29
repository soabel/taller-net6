﻿using Microsoft.EntityFrameworkCore;
using todo_api_minimal.Model;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TodoContext>(opt =>
//    opt.UseInMemoryDatabase("TodoList"));

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseSqlServer(connectionString));

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


app.MapGet("/todo/{id}", async (TodoContext context, int id) => {
    var todoItem = await context.TodoItem.FirstOrDefaultAsync(x => x.Id == id);
    if (todoItem == null) {
        return Results.NotFound();
    }
    return Results.Ok(todoItem);
});

app.MapPost("api/todo", async (TodoContext context, TodoItem item) =>
{
    context.TodoItem.Add(item);
    await context.SaveChangesAsync();
});

app.MapPut("api/todo/{id}", async (TodoContext context, TodoItem todoItem, int id) =>
{
    var existItem = await context.TodoItem.FirstOrDefaultAsync(x => x.Id == id);
    if (existItem == null)
    {
        return Results.NotFound();
    }

    try
    {
        context.TodoItem.Update(todoItem);
        await context.SaveChangesAsync();
        return Results.NoContent();
    }
    catch (Exception)
    {
        return Results.Problem("Ha ocurrido un error no controlado");
    }
   

    
});

app.MapDelete("api/todo/{id}", async (TodoContext context, int id) =>
{
    var existItem = await context.TodoItem.FirstOrDefaultAsync(x => x.Id == id);
    if (existItem == null)
    {
        //throw new ApplicationException("No encontrado");
        return Results.NotFound();
    }

    context.TodoItem.Remove(existItem);
    await context.SaveChangesAsync();

    return Results.NoContent();
});


app.Run();
