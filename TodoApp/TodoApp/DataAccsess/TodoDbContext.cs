using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.DataAccsess;

public class TodoDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public TodoDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Todo?> Todos => Set<Todo>();
}