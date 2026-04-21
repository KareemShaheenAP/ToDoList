namespace ToDoList
{
    internal class Program
    {
        public class ToDoList
        {
            public List<TaskItem> tasks = new List<TaskItem>();
            public void AddTask(string description, int serial)
            {
                tasks.Add(new TaskItem(description, serial));
                Console.WriteLine("Task added successfully.");
            }
            public void ViewTasks()
            {
                if (CheckTaskCount() == true)
                {
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i].Description} - {tasks[i].IsCompleted}");
                    }
                }
            }
            public void MarkAsCompleted()
            {
                if (CheckTaskCount() == true)
                {
                    Console.WriteLine("Enter task number to mark as completed");
                    int choice = int.Parse(Console.ReadLine());
                    tasks[choice - 1].IsCompleted = true;
                    Console.WriteLine($"Task {tasks[choice - 1].Description} is now completed.");
                }
            }
            public void RemoveTask()
            {
                if (CheckTaskCount() == true)
                {
                    Console.WriteLine("Enter task number to remove");
                    int choice = int.Parse(Console.ReadLine());
                    string taskname = tasks[choice - 1].Description;
                    tasks.RemoveAt(choice - 1);
                    Console.WriteLine($"Task {taskname} removed.");
                }
            }
            public bool CheckTaskCount()
            {
                if (tasks.Count == 0)
                {
                    Console.WriteLine("No Tasks available");
                    return false;
                }
                return true;
            }
        }
        public class TaskItem
        {
            public string Description;
            public bool IsCompleted;
            public TaskItem(string desc, int serial)
            {
                Description = desc;
                IsCompleted = false;
            }
        }
        static void Main(string[] args)
        {
            ToDoList toDoList = new ToDoList();
            while (true)
            {
                Console.WriteLine("=== To-Do List Menu ===");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Mark Task as Completed");
                Console.WriteLine("4. Remove Task");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                int selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Enter Task Description");
                        string desc = Console.ReadLine();
                        toDoList.AddTask(desc, toDoList.tasks.Count + 1);
                        break;
                    case 2:
                        toDoList.ViewTasks();
                        break;
                    case 3:
                        toDoList.MarkAsCompleted();
                        break;
                    case 4:
                        toDoList.RemoveTask();
                        break;
                    case 5:
                        return;
                    default:
                        break;
                }
            }

        }
    }
}
