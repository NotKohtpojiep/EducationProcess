using System;
using System.Configuration;
using System.Windows;
using EducationProcess.ApiClient;
using GalaSoft.MvvmLight.Ioc;
using EducationProcess.HandyDesktop.Service;

namespace EducationProcess.HandyDesktop.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            string hostUrl = ConfigurationManager.ConnectionStrings["HostUrl"].ConnectionString;
            SimpleIoc.Default.Register<IEducationProcessClient>(() => new EducationProcessClient(hostUrl, clientTimeout: new TimeSpan(0,0,0,30)));

            SimpleIoc.Default.Register<DataService>();
            SimpleIoc.Default.Register<IEducationPlanService, EducationPlanService>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<NonClientAreaViewModel>();
            SimpleIoc.Default.Register<EducationPlanMainViewModel>();
            SimpleIoc.Default.Register<EducationPlanMenuViewModel>();
        }

        public static ViewModelLocator Instance = new Lazy<ViewModelLocator>(() =>
            Application.Current.TryFindResource("Locator") as ViewModelLocator).Value;

        #region Vm

        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();

        public ItemsDisplayViewModel ContributorsView => new(SimpleIoc.Default.GetInstance<DataService>().GetContributorDataList);

        public EducationPlanMainViewModel EducationPlanView => SimpleIoc.Default.GetInstance<EducationPlanMainViewModel>();

        public EducationPlanMenuViewModel EducationPlanMenuView => SimpleIoc.Default.GetInstance<EducationPlanMenuViewModel>();
        
        public NonClientAreaViewModel NoUser => SimpleIoc.Default.GetInstance<NonClientAreaViewModel>();

        #endregion
    }
}
