namespace SFS.Models.ViewModels
{
    public class ScheduleSummaryViewModel
    {
        public int ScheduleId { get; set; }
        public string ClassName { get; set; }
        public string TeacherName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AppointmentCount { get; set; }
    }
}
