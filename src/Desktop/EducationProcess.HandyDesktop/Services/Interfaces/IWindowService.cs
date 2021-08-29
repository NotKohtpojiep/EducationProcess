using System.Windows;

namespace EducationProcess.HandyDesktop.Services
{
    public interface IWindowService
    {
        void ShowWindow<T>(object DataContext) where T : Window, new ();
    }
}
