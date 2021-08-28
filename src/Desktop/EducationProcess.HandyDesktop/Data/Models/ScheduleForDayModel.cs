using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.Data.Models
{
    public class ScheduleForDayModel : ObservableObject
    {
        public DateTime Date { get; set; }
        public LessonModel[] Lessons { get; set; }
    }
}
