using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using EducationProcess.ApiClient.Models.FixedDisciplines.Responses;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Services;
using GalaSoft.MvvmLight;
using HandyControl.Controls;
using MessageBox = HandyControl.Controls.MessageBox;

namespace EducationProcess.HandyDesktop.ViewModels
{
    public class CheckDisciplineSuggestionViewModel : ViewModelBase
    {
        private readonly IFixedDisciplineService _fixedDisciplineService;
        private FixedDisciplineModel _fixedDisciplineSelected;
        private bool _dataGot;

        public CheckDisciplineSuggestionViewModel(IFixedDisciplineService fixedDisciplineService)
        {
            _fixedDisciplineService = fixedDisciplineService;
            FixedDisciplineCollection = new ObservableCollection<FixedDisciplineModel>();

            Task.Run(GetAllFixedDisciplines).ContinueWith(obj => DataGot = FixedDisciplineCollection.Count != 0);
        }

        public FixedDisciplineModel FixedDisciplineSelected
        {
            get => _fixedDisciplineSelected;
            set => Set(ref _fixedDisciplineSelected, value);
        }

        public bool DataGot
        {
            get => _dataGot;
            set => Set(ref _dataGot, value);
        }

        public ObservableCollection<FixedDisciplineModel> FixedDisciplineCollection { get; set; }


        //public RelayCommand AddFixedDisciplineCommand => new(CreateSelectedDisciplineTabControl);

        //public RelayCommand DeleteFixedDisciplineCommand => new(CreateSelectedDisciplineTabControl);

        //public RelayCommand ViewSelectedDisciplineDisciplinesCommand => new(ViewSelectedDisciplineDisciplines);

        //public RelayCommand ViewSelectedDisciplineGroupsCommand => new(CreateSelectedDisciplineTabControl);

        //public RelayCommand<string> AddViewCommand => new(obj => Messenger.Default.Send(obj, MessageToken.NewDisciplineTabContent));

        private async Task GetAllFixedDisciplines()
        {
            FixedDiscipline[] fixedDisciplines;
            try
            {
                fixedDisciplines = await _fixedDisciplineService.GetAllByTeacherIdAsync(2);
            }
            catch (SocketException e)
            {
                Growl.Error("Ошибка подключения к сети");
                throw;
            }
            catch (HttpRequestException e)
            {
                Growl.Fatal("Ошибка подключения к удаленному серверу");
                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetType().Name + "  -  " + e.Message);
                throw;
            }

            fixedDisciplines = fixedDisciplines.Where(x => x.IsAgreed is null).ToArray();

            foreach (var item in fixedDisciplines.GroupBy(x => new
            {
                x.SemesterDiscipline.DisciplineId,
                x.GroupId,
                x.FixingEmployeeId,
                x.PublishedAt
            }))
            {
                int min = item.Min(x => x.SemesterDiscipline.Semester.Number);
                if (min % 2 == 0)
                    min -= 1;

                int max = item.Max(x => x.SemesterDiscipline.Semester.Number);
                if (max % 2 == 0)
                    max -= 1;

                for (int semester = min; semester <= max; semester += 2)
                {
                    FixedDiscipline[] disciplines =
                        item.Where(x =>
                            x.SemesterDiscipline.Semester.Number == semester ||
                            x.SemesterDiscipline.Semester.Number == semester + 1).ToArray();

                    if (disciplines.Length > 0)
                        await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            FixedDisciplineCollection.Add(new FixedDisciplineModel(disciplines));
                        }), DispatcherPriority.Send);
                }
            }
        }
    }
}