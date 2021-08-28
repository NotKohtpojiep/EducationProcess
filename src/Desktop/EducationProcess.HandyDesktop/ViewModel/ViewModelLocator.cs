using System;
using System.Configuration;
using System.Windows;
using EducationProcess.ApiClient;
using GalaSoft.MvvmLight.Ioc;
using EducationProcess.HandyDesktop.Services;

namespace EducationProcess.HandyDesktop.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            string hostUrl = ConfigurationManager.ConnectionStrings["HostUrl"].ConnectionString;
            SimpleIoc.Default.Register<IEducationProcessClient>(() => new EducationProcessClient(hostUrl, clientTimeout: new TimeSpan(0,0,0,30)));

            SimpleIoc.Default.Register<DataService>();
            SimpleIoc.Default.Register<IDisciplineService, DisciplineService>();
            SimpleIoc.Default.Register<IEducationPlanService, EducationPlanService>();
            SimpleIoc.Default.Register<IEducationPlanSemesterDisciplineService, EducationPlanSemesterDisciplineService>();
            SimpleIoc.Default.Register<IFixedDisciplineService, FixedDisciplineService>();
            SimpleIoc.Default.Register<IGroupService, GroupService>();
            SimpleIoc.Default.Register<ISemesterDisciplineService, SemesterDisciplineService>();
            SimpleIoc.Default.Register<IScheduleDisciplineService, ScheduleDisciplineService>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<NonClientAreaViewModel>();
            SimpleIoc.Default.Register<DisciplineMenuViewModel>();
            SimpleIoc.Default.Register<EducationPlanMainViewModel>();
            SimpleIoc.Default.Register<EducationPlanMenuViewModel>();
            SimpleIoc.Default.Register<ChainDisciplineViewModel>();
            SimpleIoc.Default.Register<CheckDisciplineSuggestionViewModel>();
            SimpleIoc.Default.Register<ScheduleViewModel>();
            SimpleIoc.Default.Register<ScheduleEditorViewModel>();
            SimpleIoc.Default.Register<TeacherScheduleViewModel>();
        }

        public static ViewModelLocator Instance = new Lazy<ViewModelLocator>(() =>
            Application.Current.TryFindResource("Locator") as ViewModelLocator).Value;

        #region Vm

        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();

        public ItemsDisplayViewModel ContributorsView => new(SimpleIoc.Default.GetInstance<DataService>().GetContributorDataList);

        public DisciplineMenuViewModel DisciplineMenuView => SimpleIoc.Default.GetInstance<DisciplineMenuViewModel>();

        public EducationPlanMainViewModel EducationPlanView => SimpleIoc.Default.GetInstance<EducationPlanMainViewModel>();

        public EducationPlanMenuViewModel EducationPlanMenuView => SimpleIoc.Default.GetInstance<EducationPlanMenuViewModel>();

        public ChainDisciplineViewModel ChainDisciplineView => SimpleIoc.Default.GetInstance<ChainDisciplineViewModel>();

        public CheckDisciplineSuggestionViewModel CheckDisciplineSuggestionView => SimpleIoc.Default.GetInstance<CheckDisciplineSuggestionViewModel>();

        public ScheduleViewModel ScheduleView => SimpleIoc.Default.GetInstance<ScheduleViewModel>();

        public ScheduleEditorViewModel ScheduleEditorView => SimpleIoc.Default.GetInstance<ScheduleEditorViewModel>();

        public TeacherScheduleViewModel TeacherScheduleView => SimpleIoc.Default.GetInstance<TeacherScheduleViewModel>();

        public NonClientAreaViewModel NoUser => SimpleIoc.Default.GetInstance<NonClientAreaViewModel>();

        #endregion
    }
}
