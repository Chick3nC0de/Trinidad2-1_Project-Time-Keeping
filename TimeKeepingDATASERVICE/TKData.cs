using System.Collections.Generic;
using TimeKeeping.Models;

namespace TimeKeeping.DataService
{
    public class empRecords
    {
        private List<Staffs> _employees;
        private List<hoursLog> _logs;

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
            _logs = new List<hoursLog>();
        }

        public Staffs CallByID(string id) => _employees.Find(e => e.empID == id);

        public void AddLog(hoursLog log) => _logs.Add(log);

        public List<hoursLog> collectLogs() => _logs;
    }
}