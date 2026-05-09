using TodoApp;

var repository = new TodoRepo();

string command = args.Length > 0 ? args[0] : "";
string argument = args.Length > 1 ? args[1] : "";

switch (command)
{
    case "add":
        var todos = repository.LoadAll();
        int newId = todos.Count > 0 ? todos[^1].Id + 1 : 1;
        var newTodo = new TodoItem { Id = newId, Title = argument };
        todos.Add(newTodo);
        repository.SaveAll(todos);
        Console.WriteLine($"Uppgift tillagd: [{newTodo.Id}] {newTodo.Title}");
        break;

    case "list":
        var allTodos = repository.LoadAll();
        if (allTodos.Count == 0)
        {
            Console.WriteLine("Inga uppgifter finns.");
            break;
        }
        foreach (var todo in allTodos)
        {
            string status = todo.IsCompleted ? "[x]" : "[ ]";
            Console.WriteLine($"{status} [{todo.Id}] {todo.Title}");
        }
        break;

    default:
        Console.WriteLine("Okänt kommando. Tillgängliga: add, list");
        break;
}