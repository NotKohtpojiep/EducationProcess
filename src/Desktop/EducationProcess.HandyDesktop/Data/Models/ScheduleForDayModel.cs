using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.Data.Models
{
    public class ScheduleForDayModel : ObservableObject
    {
        public DayOfWeek DayOfWeek { get; set; }
        public string DayNameOfWeek
        {
            get => DayOfWeek.ToString();
        }
        public LessonModel[] Lessons { get; set; }
    }
}
