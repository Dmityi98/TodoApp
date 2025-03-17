using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Contracts;
using TodoApp.DataAccsess;
using TodoApp.Models;

namespace TodoApp.Repository;

public class TodoRepository
{
    private TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }
    
    public async Task<Todo?> GetTodoIdAsync(int id, CancellationToken ct)
    {
       return await _context.Todos.FirstOrDefaultAsync(t => t.Id == id, ct);
    }
    
    public async Task<List<Todo?>> GetAllTodoAsync()
    {
         return await _context.Todos.ToListAsync();
    }

    public async Task<bool> CreateTodoAsync([FromBody]CreateTodoRequest request, CancellationToken ct)
    {
        var todo = new Todo(request.Title, request.Description);
        if (false) return false;
        await _context.AddAsync(todo, ct);
        await _context.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> UpdateTodoIdAsync(int id, [FromBody] UpdateTodoReqest reqest, CancellationToken ct)
    {
        var updateTodo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id, ct);
        if (updateTodo != null)
        {
            if (reqest.Title != null)
            {
                updateTodo.Title = reqest.Title;
            }

            if (reqest.Description != null)
            {
                updateTodo.Description = reqest.Description;
            }

            if (true)
            {
                updateTodo.IsDone = reqest.IsDone;
            }
            
            await _context.SaveChangesAsync(ct);
            return true; 
        }
        return false;   
    }
    public async Task<bool> DeleteTodoIdAsync(int id, CancellationToken ct)
    {
        var todo =await _context.Todos.FirstOrDefaultAsync(t => t != null && t.Id == id,ct);
        if (todo != null)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync(ct);
            return true;
        }
        
        return false;
    }
}