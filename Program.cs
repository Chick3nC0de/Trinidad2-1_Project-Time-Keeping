using System;
namespace TimeKeeping
{
    internal class Project
    {
       
        static void Main(string[] args) 
        {
            string[] empList = new string[4];
            empList[0] = "2954";
            empList[1] = "3361";
            empList[2] = "8167";
            empList[3] = "1174";

            Console.WriteLine("Good Day!");
            Console.WriteLine("Welcome to the Employee Time Punch System.");

            Console.Write("Please input Employee I.D: ");
            string empID = Console.ReadLine();

            for (int x = 0; x < empList.Length; x++)
            {
                if (empID == empList[x])
                {
                    Console.WriteLine("Welcome Employee " + empID);

                    Console.WriteLine("Type 1 to Clock In");
                    Console.WriteLine("Type 2 to Clock Out");
                    Console.WriteLine("Type 3 to view Current Assigned Hours");
                    Console.WriteLine("Type 4 to Exit");
                    int menuInp = Console.Read();
                }
                else{
                    Console.WriteLine("Inputted I.D is not detected in system.");
                    break;
                }
            }


        }
    }
}