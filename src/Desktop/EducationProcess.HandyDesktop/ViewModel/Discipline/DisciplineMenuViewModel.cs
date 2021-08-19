using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using EducationProcess.ApiClient.Models.Disciplines.Responses;
using EducationProcess.HandyDesktop.Data.Model;
using EducationProcess.HandyDesktop.Services;
using EducationProcess.HandyDesktop.Tools;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HandyControl.Controls;
using MessageBox = HandyControl.Controls.MessageBox;

namespace EducationProcess.HandyDesktop.ViewModel
{
    public class DisciplineMenuViewModel : ViewModelBase
    {
        private readonly IDisciplineService _disciplineService;
        private Discipline _disciplineSelected;
        private bool _dataGot;

        public DisciplineMenuViewModel(IDisciplineService disciplineService)
        {
            _disciplineService = disciplineService;
            DisciplineCollection = new ObservableCollection<Discipline>();

            Task.Run(GetAllDisciplines).ContinueWith(obj => DataGot = DisciplineCollection.Count != 0);
        }

        public Discipline DisciplineSelected
        {
            get => _disciplineSelected;
            set => Set(ref _disciplineSelected, value);
        }

        public bool DataGot
        {
            get => _dataGot;
            set => Set(ref _dataGot, value);
        }

        public ObservableCollection<Discipline> DisciplineCollection { get; set; }


        //public RelayCommand AddDisciplineCommand => new(CreateSelectedDisciplineTabControl);

        //public RelayCommand EditDisciplineCommand => new(CreateSelectedDisciplineTabControl);

        //public RelayCommand DeleteDisciplineCommand => new(CreateSelectedDisciplineTabControl);

        public RelayCommand ViewSelectedDisciplineDisciplinesCommand => new(ViewSelectedDisciplineDisciplines);

        //public RelayCommand ViewSelectedDisciplineGroupsCommand => new(CreateSelectedDisciplineTabControl);

        //public RelayCommand<string> AddViewCommand => new(obj => Messenger.Default.Send(obj, MessageToken.NewDisciplineTabContent));


        private void ViewSelectedDisciplineDisciplines()
        {
            if (DisciplineSelected is null)
            {
                Growl.Info("Выберите учебный план");
                return;
            }

            var view = AssemblyHelper.CreateInternalInstance($"UserControl.DisciplineDisciplinesMenuView");
            //((FrameworkElement)view).DataContext = new DisciplineDisciplinesMenuView(SimpleIoc.Default.GetInstance<IDisciplineSemesterDisciplineService>(), DisciplineSelected);

            var tabItemModel = new TabItemModel()
            {
                Header = "DisciplineDisciplineMenu",
                Content = view
            };
            //Messenger.Default.Send(tabItemModel, MessageToken.NewDisciplineTabContent);
        }

        private async Task GetAllDisciplines()
        {
            Discipline[] Disciplines;
            try
            {
                Disciplines = await _disciplineService.GetAllDisciplines();
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

            foreach (var item in Disciplines)
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    DisciplineCollection.Add(item);
                }), DispatcherPriority.Send);
            }
        }
    }
}