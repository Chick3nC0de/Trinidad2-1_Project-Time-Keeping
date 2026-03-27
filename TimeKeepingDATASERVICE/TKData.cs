using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using TimeKeeping.Models;

namespace TimeKeeping.DataService
{
    public class empRecords
    {
        private readonly string _filePath = "timepunch.json";
        private List<Staffs> _employees;

        public empRecords()
        {
            
            _employees = new List<Staffs>
            {
                new Staffs { empID = "2954", empList = "Paul Santa Rosa", assignedHours = "08:00 - 17:00" },
                new Staffs { empID = "3361", empList = "Inigo Baseleres", assignedHours = "09:00 - 18:00" },
                new Staffs { empID = "8167", empList = "Matt Bitangcor", assignedHours = "22:00 - 07:00" },
                new Staffs { empID = "1174", empList = "Alejo Alcantara", assignedHours = "06:00 - 15:00" },
                new Staffs { empID = "5041", empList = "Neil Cabillo", assignedHours = "07:00 - 16:00" },
            };
        }

        public Staffs CallByID(string id) => _employees.Find(e => e.empID == id);

        public void AddLog(hoursLog log)
        {
            var logs = collectLogs(); 
            logs.Add(log);        

            string jsonString = JsonSerializer.Serialize(logs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonString);
        }

        public List<hoursLog> collectLogs()
        {
            if (!File.Exists(_filePath)) return new List<hoursLog>();

            string jsonString = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<hoursLog>>(jsonString) ?? new List<hoursLog>();
        }
    }
}