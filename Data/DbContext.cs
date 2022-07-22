using Microsoft.EntityFrameworkCore;
using MyTodo.Models;

namespace MyTodo.Data;
public class TodoDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connection = "server=localhost; database=tododb; user=root; password=0v0AWkBn";

        optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
    }

    public DbSet<Todo>? Todos { get; set; }
}