using System;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Service;

namespace EducationProcess.HandyDesktop.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<DataService>();
            var dataService = SimpleIoc.Default.GetInstance<DataService>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<NonClientAreaViewModel>();
        }

        public static ViewModelLocator Instance = new Lazy<ViewModelLocator>(() =>
            Application.Current.TryFindResource("Locator") as ViewModelLocator).Value;

        #region Vm

        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();
        public ItemsDisplayViewModel ContributorsView => new(SimpleIoc.Default.GetInstance<DataService>().GetContributorDataList);

        public ItemsDisplayViewModel BlogsView => SimpleIoc.Default.GetInstance<ItemsDisplayViewModel>("Blogs");

        public ItemsDisplayViewModel ProjectsView => SimpleIoc.Default.GetInstance<ItemsDisplayViewModel>("Projects");

        public ItemsDisplayViewModel WebsitesView => SimpleIoc.Default.GetInstance<ItemsDisplayViewModel>("Websites");
        
        public NonClientAreaViewModel NoUser => SimpleIoc.Default.GetInstance<NonClientAreaViewModel>();

        #endregion
    }
}
