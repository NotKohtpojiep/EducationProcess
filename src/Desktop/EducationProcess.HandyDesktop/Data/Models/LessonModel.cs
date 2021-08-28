using System.Collections.Generic;
using System.Linq;
using EducationProcess.ApiClient.Models.ScheduleDisciplines.Responses;
using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.Data
{
    public enum FixedForInfo
    {
        Teacher,
        Group
    }

    public class LessonModel : ObservableObject
    {
        private List<ScheduleDiscipline> _disciplines;
        public LessonModel()
        {
        }

        public LessonModel(ScheduleDiscipline[] pairLessons, FixedForInfo fixedFor)
        {
            List<ScheduleDiscipline> disciplines = new List<ScheduleDiscipline>(pairLessons);
            if (pairLessons == null || pairLessons.Length == 0)
                disciplines.Add(new ScheduleDiscipline());
            if (pairLessons.Length == 1 && pairLessons.FirstOrDefault()?.IsEvenPair is not null)
                disciplines.Add(new ScheduleDiscipline { IsEvenPair = !pairLessons.First().IsEvenPair });

            PairNumber = pairLessons.First().PairNumber;
            Disciplines = disciplines.OrderBy(x => x.IsEvenPair).ToList();
        }

        public int PairNumber { get; set; }

        public List<ScheduleDiscipline> Disciplines
        {
            get => _disciplines;
            set => Set(ref _disciplines, value);
        }
    }
}
