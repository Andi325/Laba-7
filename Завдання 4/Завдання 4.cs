using System;
using System.Collections.Generic;

public class TaskScheduler<TTask, TPriority>
{
    private Queue<KeyValuePair<TTask, TPriority>> taskQueue = new Queue<KeyValuePair<TTask, TPriority>>();

    public delegate void TaskExecution(TTask task);

    public TaskExecution ExecuteTask { get; set; }

    public void AddTask(TTask task, TPriority priority)
    {
        taskQueue.Enqueue(new KeyValuePair<TTask, TPriority>(task, priority));
    }

    public void ExecuteNext()
    {
        if (taskQueue.Count > 0)
        {
            var task = taskQueue.Dequeue();
            ExecuteTask(task.Key);
        }
        else
        {
            Console.WriteLine("Немає завдань у черзі.");
        }
    }
}

class Program
{
    static void Main()
    {
        TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>();

        scheduler.ExecuteTask = (string task) =>
        {
            Console.WriteLine($"Виконується завдання: {task}");
        };

        scheduler.AddTask("Завдання A", 3);
        scheduler.AddTask("Завдання B", 1);
        scheduler.AddTask("Завдання C", 2);

        scheduler.ExecuteNext();
        scheduler.ExecuteNext();
        scheduler.ExecuteNext();
        scheduler.ExecuteNext();
    }
}