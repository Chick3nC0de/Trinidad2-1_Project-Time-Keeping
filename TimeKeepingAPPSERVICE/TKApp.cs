using System;
using System.Collections.Generic;
using TimeKeeping.DataService;
using TimeKeeping.Models;

namespace TimeKeeping.AppService
{
    public class timeKeepingSystem
    {
        private readonly empRecords _repo;

        public timeKeepingSystem()
        {
            _repo = new empRecords();
        }

        public Staffs employeeAuthenticator(string id)
        {
            return _repo.CallByID(id);
        }

        public void PunchIn(Staffs emp, string type)
        {
            var newLog = new hoursLog
            {
                namesOfEmp = emp.empList,
                ClockINClockOUT = (type == "1") ? "IN" : "OUT",
                Timestamp = DateTime.Now.ToString("HH:mm")
            };
            _repo.AddLog(newLog);
        }

        public List<string> DisplayLogs()
        {
            var rawLogs = _repo.collectLogs();
            var formatted = new List<string>();
            foreach (var log in rawLogs)
            {
                formatted.Add($"{log.namesOfEmp} - CLOCKED {log.ClockINClockOUT} at {log.Timestamp}");
            }
            return formatted;
        }
    }
}