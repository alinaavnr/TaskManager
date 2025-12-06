using System;
using System.Collections.Generic;

namespace TodoApp
{
    class Program
    {
        static List<string> tasks = new List<string>();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== TODO MANAGER ===");
                Console.WriteLine("1. Показать задачи");
                Console.WriteLine("2. Добавить задачу");
                Console.WriteLine("3. Удалить задачу");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите пункт: ");

                var choice = Console.ReadLine() ?? string.Empty; 

                switch (choice)
                {
                    case "1":
                        ShowTasks();
                        break;

                    case "2":
                        AddTask();
                        break;

                    case "3":
                        RemoveTask();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Неизвестная команда");
                        Pause();
                        break;
                }
            }
        }

        static void ShowTasks()
        {
            Console.Clear();
            Console.WriteLine("=== СПИСОК ЗАДАЧ ===");

            if (tasks.Count == 0)
            {
                Console.WriteLine("Нет задач.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
            }

            Pause();
        }

        static void AddTask()
        {
            Console.Clear();
            Console.Write("Введите текст задачи: ");
            string task = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(task))
            {
                tasks.Add(task);
                Console.WriteLine("Задача добавлена!");
            }
            else
            {
                Console.WriteLine("Пустую задачу добавить нельзя.");
            }

            Pause();
        }

        static void RemoveTask()
        {
            Console.Clear();
            Console.WriteLine("=== УДАЛЕНИЕ ЗАДАЧИ ===");

            ShowTasksInline();

            Console.Write("Введите номер задачи: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (index >= 1 && index <= tasks.Count)
                {
                    tasks.RemoveAt(index - 1);
                    Console.WriteLine("Удалено!");
                }
                else
                {
                    Console.WriteLine("Нет задачи с таким номером.");
                }
            }
            else
            {
                Console.WriteLine("Это не число.");
            }

            Pause();
        }

        static void ShowTasksInline()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Нет задач.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
                Console.WriteLine($"{i + 1}. {tasks[i]}");
        }

        static void Pause()
        {
            Console.WriteLine("\nНажмите Enter для продолжения...");
            Console.ReadLine();
        }
    }
}
