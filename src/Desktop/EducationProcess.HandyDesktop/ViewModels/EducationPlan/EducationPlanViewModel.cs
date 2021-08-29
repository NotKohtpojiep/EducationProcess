using System.Collections.ObjectModel;
using EducationProcess.ApiClient.Models;
using EducationProcess.ApiClient.Models.EducationPlans.Responses;
using EducationProcess.ApiClient.Models.FederalStateEducationalStandards.Responses;
using EducationProcess.HandyDesktop.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace EducationProcess.HandyDesktop.ViewModels
{
    public class EducationPlanViewModel : ViewModelBase
    {
        private readonly IEducationPlanService _educationPlanService;
        private EducationPlan _educationPlan;

        public EducationPlanViewModel(IEducationPlanService educationPlanService, IEducationPlanSemesterDisciplineService educationPlanSemesterDiscipline)
        {
            _educationPlanService = educationPlanService;
            _educationPlan = new EducationPlan();
            EducationPlanCollection = new ObservableCollection<EducationPlan>();
            AcademicYearCollection = new ObservableCollection<AcademicYear>();
            SpecialtyCollection = new ObservableCollection<FsesCategoryPartition>();
        }

        public EducationPlan EducationPlan
        {
            get =>  _educationPlan;
            set => _educationPlan = value;
        }
        public string TitleInfo
        {
            get => _educationPlan.EducationPlanId is 0 ? "Создание уч. плана" : "Редактирование уч. плана";
        }
        public string HeaderText
        {
            get => _educationPlan.EducationPlanId is 0 ? "Создание уч. плана" : "Редактирование уч. плана";
        }
        public string EducationPlanName
        {
            get => _educationPlan.Name;
            set => _educationPlan.Name = value;
        }
        public bool IsEnabledCopyEducationPlan
        {
            get => _educationPlan is null;
        }
        public ObservableCollection<AcademicYear> AcademicYearCollection { get; set; }
        public ObservableCollection<FsesCategoryPartition> SpecialtyCollection { get; set; }
        public ObservableCollection<EducationPlan> EducationPlanCollection { get; set; }
        public AcademicYear SelectedAcademicYear { get; set; }
        public FsesCategoryPartition SelectedSpecialty { get; set; }
        public EducationPlan CopyingEducationPlan { get; set; }

        public RelayCommand<EducationPlan> SaveEducationPlanCommand => new(SaveEducationPlan);

        private void SaveEducationPlan(EducationPlan educationPlan)
        {
            /*
            if (SelectedAcademicYear == null)
            {
                _dialogCoordinator.ShowMessageAsync(this, null, "Выберите учебный год");
                return;
            }
            if (SelectedSpecialty == null)
            {
                _dialogCoordinator.ShowMessageAsync(this, null, "Выберите специальность");
                return;
            }

            if (string.IsNullOrWhiteSpace(EducationPlanName))
            {
                _dialogCoordinator.ShowMessageAsync(this, null, "Назовите учебный план");
                return;
            }

            EducationProcessContext context = new EducationProcessContext();
            if (educationPlan == null)
            {
                educationPlan = new EducationPlan()
                {
                    Name = EducationPlanName,
                    AcademicYearId = SelectedAcademicYear.AcademicYearId,
                    SpecialtieId = SelectedSpecialty.SpecialtieId
                };
                context.EducationPlans.Add(educationPlan);
            }
            else
            {
                educationPlan.Name = EducationPlanName;
                educationPlan.AcademicYearId = SelectedAcademicYear.AcademicYearId;
                educationPlan.SpecialtieId = SelectedSpecialty.SpecialtieId;
                context.EducationPlans.Update(educationPlan);
            }
            context.SaveChanges();

            if (SelectedEducationPlan != null)
            {
                CopySemesterDisciplines(educationPlan, SelectedEducationPlan);
            }
            */
        }

        /*
      private void CopySemesterDisciplines(EducationPlan educationPlan, EducationPlan copyingEducationPlan)
      {
          EducationProcessContext context = new EducationProcessContext();
          EducationPlanSemesterDiscipline[] copyingSemesterDisciplines = _
          foreach (var copyingSemesterDiscipline in copyingSemesterDisciplines)
          {
              EducationPlanSemesterDiscipline educationPlanSemesterDiscipline =
                  new EducationPlanSemesterDiscipline()
                  {
                      EducationPlanId = educationPlan.EducationPlanId,
                      SemesterDisciplineId = copyingSemesterDiscipline.SemesterDisciplineId
                  };
              context.EducationPlanSemesterDisciplines.Add(educationPlanSemesterDiscipline);
          }
          context.SaveChanges();
      }

      
      private void ViewSelectedEducationPlanDisciplines()
      {
          if (EducationPlanSelected is null)
          {
              Growl.Info("Выберите учебный план");
              return;
          }

          var view = AssemblyHelper.CreateInternalInstance($"UserControl.EducationPlanDisciplinesMenuView");
          ((FrameworkElement)view).DataContext = new EducationPlanDisciplinesMenuViewModel(SimpleIoc.Default.GetInstance<IEducationPlanSemesterDisciplineService>(), EducationPlanSelected);

          var tabItemModel = new TabItemModel()
          {
              Header = "EducationPlanDisciplineMenu",
              Content = view
          };
          Messenger.Default.Send(tabItemModel, MessageToken.NewEducationPlanTabContent);
      }
      */
    }
}