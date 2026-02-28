using System;
using System.Collections.Generic;

namespace TimeKeeping
{
    class Project
    {
        static void Main(string[] args)
        {
            string[] empID = new string[5];
            string[] empList = new string[5];
            string[] assignedHours = new string[5];

            empID[0] = "2954";
            empID[1] = "3361";
            empID[2] = "8167";
            empID[3] = "1174";
            empID[4] = "5041";
            empList[0] = "Paul Santa Rosa";
            empList[1] = "Inigo Baseleres";
            empList[2] = "Matt Bitangcor";
            empList[3] = "Alejo Alcantara";
            empList[4] = "Neil Cabillo";
            assignedHours[0] = "08:00 - 17:00";
            assignedHours[1] = "09:00 - 18:00";
            assignedHours[2] = "22:00 - 07:00";
            assignedHours[3] = "06:00 - 15:00";
            assignedHours[4] = "07:00 - 16:00";

            List<string> hourLogs = new List<string>();

            while (true)
            {
                Console.WriteLine("\n--- Employee Time Punch System ---");
                Console.WriteLine("Good Day!");
                Console.Write("Please input Employee ID: ");
                string IDInput = Console.ReadLine();

                int empRecords = Array.IndexOf(empID, IDInput);
                if (empRecords == -1)
                {
                    Console.WriteLine("Access Denied: I.D entered is not detected in system.");
                    continue; 
                }
                Console.WriteLine($"Welcome, {empList[empRecords]}");
                Console.WriteLine($"Assigned Schedule: {assignedHours[empRecords]}");
                
                Console.WriteLine("\nSelect Action:");
                Console.WriteLine("1. Time In");
                Console.WriteLine("2. Time Out");
                Console.WriteLine("3. Exit");

                Console.Write("Selection: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string timeIn = DateTime.Now.ToString("HH:mm");
                        hourLogs.Add($"{empList[empRecords]} - CLOCKED IN at {timeIn}");
                        Console.WriteLine($"Recorded: Time In at {timeIn}");
                        break;
                    case "2":
                        string timeOut = DateTime.Now.ToString("HH:mm");
                        hourLogs.Add($"{empList[empRecords]} - CLOCKED OUT at {timeOut}");
                        Console.WriteLine($"Recorded: Time Out at {timeOut}");
                        break;
                    case "3":
                        Console.WriteLine("Exiting System...");
                        break;
                    default:
                        Console.WriteLine("Error. Invalid Input.");
                        break;
                }

                Console.WriteLine("\n--- Current Day Employee Logs ---");
                foreach (var log in hourLogs)
                {
                    Console.WriteLine(log);
                }
            }
        }
    }
}