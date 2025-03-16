using Microsoft.VisualBasic;

namespace TodoApp.Models;

public class Todo
{
    public Todo(string title, string description)
    {
        Title = title;
        Description = description;
        IsDone = false;
        CreatedAt = DateTime.UtcNow;

    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DateAt { get; set; }
}