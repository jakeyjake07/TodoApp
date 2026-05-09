using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoRepo
    {
        private readonly string _filePath = "todos.json";

        public List<TodoItem> LoadAll()
        {
            if (!File.Exists(_filePath))
                return new List<TodoItem>();

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new List<TodoItem>();
        }

        public void SaveAll(List<TodoItem> todos)
        {
            string json = JsonSerializer.Serialize(todos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}