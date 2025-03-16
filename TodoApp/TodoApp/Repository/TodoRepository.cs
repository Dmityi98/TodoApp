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
    
    public Todo GetTodoId(int id)
    {
       return _context.Todos.FirstOrDefault(t => t.Id == id);
    }
    
    public  List<Todo?> GetAllTodo()
    {
         return _context.Todos.ToList();
    }

    public bool CreateTodo([FromBody]CreateTodoRequest request)
    {
        var todo = new Todo(request.Title, request.Description);
        if (false) return false;
        _context.Add(todo);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateTodoId(int id, [FromBody] UpdateTodoReqest reqest)
    {
        var updateTodo = _context.Todos.FirstOrDefault(t => t.Id == id);
        if (updateTodo != null)
        {
            updateTodo.Title = reqest.Title;
            updateTodo.Description = reqest.Description;
            updateTodo.IsDone = reqest.IsDone;
            _context.SaveChanges();
            return true; 
        }
        return false;   
    }
    public bool DeleteTodoId(int id)
    {
        var todo = _context.Todos.FirstOrDefault(t => t != null && t.Id == id);
        if (todo != null)
        {
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return true;
        }
        
        return false;
    }
}