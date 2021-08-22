
using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.Data
{
    public class LessonModel : ObservableObject
    {
        public int PairNumber { get; set; }

        public LessonCellModel[] LessonCells { get; set; }
    }
}
