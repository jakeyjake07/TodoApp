namespace TodoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new TodoRepo();

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
                        var todos = repo.LoadAll();
                        var newItem = new TodoItem
                        {
                            Id = todos.Count + 1,
                            Title = argument
                        };
                        todos.Add(newItem);
                        repo.SaveAll(todos);
                        Console.WriteLine($"✓ Uppgift tillagd: \"{argument}\"");
                        break;

                    case "quit":
                        return;

                    default:
                        Console.WriteLine("Okänt kommando.");
                        break;
                }
            }
        }
    }
}
