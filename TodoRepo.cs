using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp
{
}
public class TodoRepo
{
    private readonly string _filePath = "todos.json";

    public List<TodoItem> Load()
    {
        if (!File.Exists(_filePath))
            return new List<TodoItem>();

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
    }

    public void Save(List<TodoItem> items)
    {
        var json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}