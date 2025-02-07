using System;

namespace c__start
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] arr1 = new string[100, 5]; // 100 tasks with 5 pieces of information maximum
            int taskcount = 0;
            bool run = true;
            while (run)
            {
                Console.WriteLine("Hello, please choose one:");
                Console.WriteLine("1: Add task");
                Console.WriteLine("2: Update task");
                Console.WriteLine("3: View task");
                Console.WriteLine("4: Delete task");
                Console.WriteLine("5: Exit the application");
                string s = Console.ReadLine();
                int s1 = Convert.ToInt32(s);
                switch (s1)
                {
                    case 1:
                        addtask(arr1, ref taskcount);
                        break;
                    case 2:
                        updatetask(arr1, taskcount);
                        break;
                    case 3:
                        viewtask(arr1, taskcount);
                        break;
                    case 4:
                        deletetask(arr1, ref taskcount);
                        break;
                    case 5:
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid number, please enter a number from 1 to 5.");
                        break;
                }
                if (s1 != 5)
                {
                    Console.WriteLine("Do you want to continue? (y/n)");
                    string ans = Console.ReadLine();
                    if (ans.ToLower() == "n")
                    {
                        run = false;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
            }
        }

        public static void addtask(string[,] arr, ref int taskcount)
        {
            if (taskcount < arr.GetLength(0))
            {
                Console.WriteLine("Enter the task's title:");
                arr[taskcount, 0] = Console.ReadLine();

                Console.WriteLine("Enter the task's description:");
                arr[taskcount, 1] = Console.ReadLine();

                Console.WriteLine("Enter the task's date (dd/mm/yy):");
                arr[taskcount, 2] = Console.ReadLine();

                Console.WriteLine("Enter the task's priority (High/Medium/Low):");
                arr[taskcount, 3] = Console.ReadLine();

                arr[taskcount, 4] = "Pending";

                taskcount++;
                Console.WriteLine("Task added successfully :)");
            }
            else
            {
                Console.WriteLine("Sorry, there is no space :(");
            }
        }

        public static void updatetask(string[,] arr, int taskcount)
        {
            Console.WriteLine("Please enter the title of the task you want to update:");
            string s = Console.ReadLine();
            for (int i = 0; i < taskcount; i++)
            {
                if (arr[i, 0] == s)
                {
                    Console.WriteLine("Please enter the updated status:");
                    string x = Console.ReadLine();
                    arr[i, 4] = x;
                    Console.WriteLine("Task status updated successfully :)");
                    return;
                }
            }
            Console.WriteLine("Task not found. Please enter a valid title.");
        }

        public static void viewtask(string[,] arr, int taskcount)
        {
            Console.WriteLine("Please enter the title of the task you want to view:");
            string s = Console.ReadLine();
            for (int i = 0; i < taskcount; i++)
            {
                if (arr[i, 0] == s)
                {
                    Console.WriteLine("Task order: " + (i + 1) + "\nTitle: " + arr[i, 0] + "\nDescription: " + arr[i, 1]
                        + "\nDate: " + arr[i, 2] + "\nPriority: " + arr[i, 3] + "\nStatus: " + arr[i, 4]);
                    return;
                }
            }
            Console.WriteLine("Task not found. Please enter a valid title.");
        }

        public static void deletetask(string[,] arr, ref int taskcount)
        {
            Console.WriteLine("Please enter the title of the task you want to delete:");
            string s = Console.ReadLine();
            for (int i = 0; i < taskcount; i++)
            {
                if (arr[i, 0] == s)
                {
                    for (int j = i; j < taskcount - 1; j++)
                    {
                        arr[j, 0] = arr[j + 1, 0];
                        arr[j, 1] = arr[j + 1, 1];
                        arr[j, 2] = arr[j + 1, 2];
                        arr[j, 3] = arr[j + 1, 3];
                        arr[j, 4] = arr[j + 1, 4];
                    }
                    taskcount--;
                    Console.WriteLine("Task deleted successfully :)");
                    return;
                }
            }
            Console.WriteLine("Task not found. Please enter a valid title.");
        }
    }
}