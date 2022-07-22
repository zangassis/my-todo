using MyTodo.Data;
using MyTodo.Models;

namespace MyTodo.Services;
public class TodoService
{
    private readonly TodoDbContext _dBContext;

    public TodoService(TodoDbContext dBContext)
    {
        _dBContext = dBContext;
    }

    public List<Todo>? FindAll() => _dBContext?.Todos?.ToList();

    public bool Create(Todo entity)
    {
        try
        {
            _dBContext.Add(entity);
            _dBContext.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}