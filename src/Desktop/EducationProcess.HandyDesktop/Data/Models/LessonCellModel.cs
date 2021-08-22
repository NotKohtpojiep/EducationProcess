
using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.Data
{
    public class LessonCellModel : ObservableObject
    {
        public string SubNumber { get; set; }

        public string Discipline { get; set; }

        public string FixedFor { get; set; }

        public string Audience { get; set; }
    }
}
