using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
    }
}