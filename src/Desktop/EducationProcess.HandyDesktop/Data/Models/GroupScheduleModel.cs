using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.Data.Models
{
    public class GroupScheduleModel : ObservableObject
    {
        public GroupScheduleModel()
        {
        }
        public string GroupName { get; set; }
        public ScheduleForDayModel[] Schedule { get; set; }
    }
}
