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
using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using HandyControl.Data;
using MessageBox = HandyControl.Controls.MessageBox;

namespace EducationProcess.HandyDesktop.ViewModels
{
    public class ChainDisciplineViewModel : ViewModelBase
    {
        private readonly IFixedDisciplineService _fixedDisciplineService;
        private FixedDisciplineModel _fixedDisciplineSelected;
        private bool _dataGot;
        private int _pageSize = 10;
        private int _fixedDisciplinesCount;
        private int _pageIndex;

        public ChainDisciplineViewModel(IFixedDisciplineService fixedDisciplineService)
        {
            _fixedDisciplineService = fixedDisciplineService;
            FixedDisciplineCollection = new ObservableCollection<FixedDisciplineModel>();

            Task.Run(GetFixedDisciplinesCount);

            Task.Run(() => GetRangeFixedDisciplinesPagination(1, _pageSize))
                .ContinueWith(_ => DataGot = FixedDisciplineCollection.Count != 0);
        }

        public int MaxPageCount
        {
            get => (int)Math.Round((double)_fixedDisciplinesCount / _pageSize, MidpointRounding.ToPositiveInfinity);
            private set => Set(ref _fixedDisciplinesCount, value);
        }

        public int PageIndex
        {
            get => _pageIndex;
            set => Set(ref _pageIndex, value);
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


        public RelayCommand<FunctionEventArgs<int>> UpdatePageCommand => 
            new(obj => Task.Run(() => UpdatePage(obj)));

        private async void UpdatePage(FunctionEventArgs<int> info)
        {
            await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    FixedDisciplineCollection.Clear();
                }), DispatcherPriority.Send);
            await GetRangeFixedDisciplinesPagination(info.Info, _pageSize);
        }
        //public RelayCommand DeleteFixedDisciplineCommand => new(CreateSelectedDisciplineTabControl);

        //public RelayCommand ViewSelectedDisciplineDisciplinesCommand => new(ViewSelectedDisciplineDisciplines);

        //public RelayCommand ViewSelectedDisciplineGroupsCommand => new(CreateSelectedDisciplineTabControl);

        //public RelayCommand<string> AddViewCommand => new(obj => Messenger.Default.Send(obj, MessageToken.NewDisciplineTabContent));

        private async Task GetFixedDisciplinesCount()
        {
            int fixedDisciplinesCount;
            try
            {
                fixedDisciplinesCount = await _fixedDisciplineService.GetCount();
            }
            catch (SocketException)
            {
                Growl.Error("Ошибка подключения к сети");
                throw;
            }
            catch (HttpRequestException)
            {
                Growl.Fatal("Ошибка подключения к удаленному серверу");
                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetType().Name + "  -  " + e.Message);
                throw;
            }

            await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                MaxPageCount = fixedDisciplinesCount;
            }), DispatcherPriority.Send);
        }

        private async Task GetRangeFixedDisciplinesPagination(int pageNumber, int pageSize)
        {
            FixedDiscipline[] fixedDisciplines;
            try
            {
                fixedDisciplines = await _fixedDisciplineService.GetPrettyRangeAsync(pageNumber, pageSize);
            }
            catch (SocketException)
            {
                Growl.Error("Ошибка подключения к сети");
                throw;
            }
            catch (HttpRequestException)
            {
                Growl.Fatal("Ошибка подключения к удаленному серверу");
                throw;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.GetType().Name + "  -  " + e.Message);
                throw;
            }

            foreach (var item in fixedDisciplines.GroupBy(x => new
            {
                x.SemesterDiscipline.DisciplineId,
                x.GroupId,
                x.FixingEmployeeId,
                x.PublishedAt,
                x.IsAgreed
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