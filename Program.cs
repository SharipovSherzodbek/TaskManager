using System;

class Task
{
    string[] enteredTask = new string[50];
    bool[] markAsCompleted = new bool[50];
    int taskCount = 0;

    public void TaskManager()
    {
        while (true)
        {
            Console.WriteLine("\nEnter an appropriate number...");
            Console.WriteLine("1. Add task");
            Console.WriteLine("2. Delete task");
            Console.WriteLine("3. Mark Task as Complete");
            Console.WriteLine("4. List of tasks");
            Console.WriteLine("5. Exit");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid format! Please enter an integer!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddTask();
                    break;
                case 2:
                    DeleteTask();
                    break;
                case 3:
                    MarkAsCompleted();
                    break;
                case 4:
                    ListOfTasks();
                    break;
                case 5:
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
    private void AddTask()
    {
        if (taskCount < 10)
        {
            Console.WriteLine($"Enter task N{taskCount +1} name:");
            string taskName = Console.ReadLine();
            enteredTask[taskCount++] = taskName;
        }
        else { Console.WriteLine("Reached maximum storage"); }
        Console.WriteLine("Task added successfully!");
    }

    private void DeleteTask()
    {
        Console.WriteLine("Choose a task to delete...");

        for (int i = 0; i < taskCount; i++)
        {
            Console.WriteLine($"{i + 1}. {enteredTask[i]}");
        }

        int deleteIndex;
        if (!int.TryParse(Console.ReadLine(), out deleteIndex) || deleteIndex < 1  || deleteIndex > taskCount)
        {
            Console.WriteLine("Invalid format, please enter a valid task number!");
            return;
        }

        string[] newEnteredTask = new string[enteredTask.Length - 1];

        for (int i = 0 ;i < newEnteredTask.Length;i++)
        {
            if(i < deleteIndex - 1)
            newEnteredTask[i] = enteredTask[i];
            if(i > deleteIndex - 1)
            newEnteredTask[i - 1] = enteredTask[i ];
        }
        taskCount--;
        enteredTask = newEnteredTask;
        Console.WriteLine("Task deleted successfully!");
    }

    private void MarkAsCompleted()
    {
        Console.WriteLine("Choose to mark!");
        for (int i = 0; i < taskCount; i++)
        {
            Console.WriteLine($"{i + 1}. {enteredTask[i]} - {(markAsCompleted[i] ? "Completed" : "Not Completed")}");
        }

        int marked;
        if (!int.TryParse(Console.ReadLine(), out marked) || marked <1 || marked > taskCount )
        {
            Console.WriteLine("Invalid format, please enter a valid task number!");
        }

        markAsCompleted[marked - 1] = true;
        Console.WriteLine("Task marked successfully!");
    }

    private void ListOfTasks()
    {
        Console.WriteLine("List of tasks");
        for (int i = 0; i < taskCount; i++)
        {
            Console.WriteLine($"{i + 1}. {enteredTask[i]} - {(markAsCompleted[i] ? "Completed" : "Not Completed")}");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {        
        Console.WriteLine("Welcome to Task Manager program from Basic Takrorlash2 \n Here is some options:");
        Task task = new Task();

        task.TaskManager ();
    }
}