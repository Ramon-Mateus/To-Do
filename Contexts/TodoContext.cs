using Microsoft.EntityFrameworkCore;
using To_Do.Models;

namespace To_Do.Context;

public class TodoContext : DbContext {
    public DbSet<Todo> Todos => Set<Todo>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=todos.sqlite3");
    }
}