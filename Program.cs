namespace TodoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repository = new TodoRepo();

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
                        var todos = repository.LoadAll();
                        var newItem = new TodoItem
                        {
                            Id = todos.Count + 1,
                            Title = argument
                        };
                        todos.Add(newItem);
                        repository.SaveAll(todos);
                        Console.WriteLine($"✓ Uppgift tillagd: \"{argument}\"");
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

                    case "summary":
                        var summaryTodos = repository.LoadAll();
                        int completed = summaryTodos.Count(t => t.IsCompleted);
                        int remaining = summaryTodos.Count(t => !t.IsCompleted);
                        Console.WriteLine($"Total: {summaryTodos.Count} uppgifter");
                        Console.WriteLine($"✓ Klara: {completed}");
                        Console.WriteLine($"○ Kvar: {remaining}");
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

                    case "quit":
                        return;

                    default:
                        Console.WriteLine("Okänt kommando., complete, delete");
                        break;
                }
            }
        }
    }
}
