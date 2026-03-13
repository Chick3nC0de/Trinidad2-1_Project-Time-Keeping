namespace TimeKeeping.Models
{
    public class Staffs
    {
        public string empID { get; set; }
        public string empList { get; set; }
        public string assignedHours { get; set; }
    }

    public class hoursLog
    {
        public string namesOfEmp { get; set; }
        public string ClockINClockOUT { get; set; }
        public string Timestamp { get; set; }
    }
}