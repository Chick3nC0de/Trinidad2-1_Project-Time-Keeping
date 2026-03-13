using System;
using TimeKeeping.AppService;

namespace TimeKeeping
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new timeKeepingSystem();

            while (true)
            {
                Console.WriteLine("\n--- Employee Time Punch System ---");
                Console.WriteLine("Good Day!");
                Console.Write("Please input Employee ID: ");
                var id = Console.ReadLine();

                var emp = service.employeeAuthenticator(id);
                if (emp == null)
                {
                    Console.WriteLine("Access Denied: I.D entered is not detected in system.");
                    continue;
                }

                Console.WriteLine($"Welcome {emp.empList}!");
                Console.WriteLine($"Your Assigned Hours: {emp.assignedHours}!");
                Console.WriteLine("Select Action: [1] In [2] Out [3] Exit");
                int choice = Console.Read();

                if (choice == 3)
                    Console.WriteLine("Exiting System...");
                    break;
                service.PunchIn(emp, choice);

                Console.WriteLine("\n--- Current Day Employee Logs ---");
                service.DisplayLogs().ForEach(Console.WriteLine);
            }
        }
    }
}