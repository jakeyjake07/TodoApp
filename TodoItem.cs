using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoItem
    {
<<<<<<< HEAD
        var repo = new TodoRepository();

        Console.WriteLine("Todo-lista. Skriv 'hjälp' för kommandon.");

while (true)
{
    Console.Write("\n> ");
    var input = Console.ReadLine()?.Trim() ?? "";
        var parts = input.Split(' ', 2);
        var command = parts[0].ToLower();
        var argument = parts.Length > 1 ? parts[1] : "";

    switch (command)
    {
        case "add":
            if (string.IsNullOrWhiteSpace(argument))
            {
                Console.WriteLine("Ange en uppgift. Ex: add Fixa login");
                break;
            }
            var todos = repo.Load();
        var newItem = new TodoItem
        {
            Id = todos.Count + 1,
            Title = argument
        };
            todos.Add(newItem);
            repo.Save(todos);
            Console.WriteLine($"✓ Uppgift tillagd: \"{argument}\"");
            break;

        case "quit":
            return;

        default:
            Console.WriteLine("Okänt kommando.");
            break;
    }
}
=======
        
>>>>>>> 7eb07f1f5be6778ccb4beb232b69105f86503a10
    }
}