using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TimeKeeping.Models;

namespace TimeKeeping.DataService
{
    public class empRecords
    {
        private readonly TimeKeepingContext _db;
        private readonly string _jsonPath = "logs_backup.json";

        public empRecords()
        {
            _db = new TimeKeepingContext();
            _db.Database.EnsureCreated();

            if (!_db.Employees.Any())
            {
                SeedEmployees();
            }
        }

        public Staffs CallByID(string id) => _db.Employees.FirstOrDefault(e => e.empID == id);

        public void AddLog(hoursLog log)
        {
            _db.Logs.Add(log);
            _db.SaveChanges();

            SyncToJson();
        }

        public List<hoursLog> collectLogs()
        {
            return _db.Logs.ToList();
        }

        private void SyncToJson()
        {
            var allLogs = _db.Logs.ToList();
            string jsonString = JsonSerializer.Serialize(allLogs, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_jsonPath, jsonString);
        }

        private void SeedEmployees()
        {
            var initialStaff = new List<Staffs>
            {
                new Staffs { empID = "2954", fullName = "Paul Santa Rosa", assignedHours = "08:00 - 17:00" },
                new Staffs { empID = "3361", fullName = "Inigo Baseleres", assignedHours = "09:00 - 18:00" },
                new Staffs { empID = "8167", fullName = "Matt Bitangcor", assignedHours = "22:00 - 07:00" },
                new Staffs { empID = "1174", fullName = "Alejo Alcantara", assignedHours = "06:00 - 15:00" },
                new Staffs { empID = "5041", fullName = "Neil Cabillo", assignedHours = "07:00 - 16:00" },
            };
            _db.Employees.AddRange(initialStaff);
            _db.SaveChanges();
        }
    }
}