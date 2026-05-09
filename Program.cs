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

    case "complete":
        if (int.TryParse(argument, out int completeId))
        {
            var completeTodos = repository.LoadAll();
            var item = completeTodos.FirstOrDefault(t => t.Id == completeId);
            if (item != null)
            {
                item.IsCompleted = true;
                repository.SaveAll(completeTodos);
                Console.WriteLine($"Uppgift [{completeId}] markerad som klar!");
            }
            else
            {
                Console.WriteLine($"Ingen uppgift med id {completeId} hittades.");
            }
        }
        else
        {
            Console.WriteLine("Ange ett giltigt id, t.ex: dotnet run complete 1");
        }
        break;

    case "delete":
        if (int.TryParse(argument, out int deleteId))
        {
            var deleteTodos = repository.LoadAll();
            var toDelete = deleteTodos.FirstOrDefault(t => t.Id == deleteId);
            if (toDelete != null)
            {
                deleteTodos.Remove(toDelete);
                repository.SaveAll(deleteTodos);
                Console.WriteLine($"Uppgift [{deleteId}] borttagen.");
            }
            else
            {
                Console.WriteLine($"Ingen uppgift med id {deleteId} hittades.");
            }
        }
        else
        {
            Console.WriteLine("Ange ett giltigt id, t.ex: dotnet run delete 1");
        }
        break;

    default:
        Console.WriteLine("Okänt kommando. Tillgängliga: add, list, complete, delete");
        break;
}