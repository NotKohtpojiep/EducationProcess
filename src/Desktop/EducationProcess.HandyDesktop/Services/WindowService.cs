using System.Windows;

namespace EducationProcess.HandyDesktop.Services
{
    public class WindowService : IWindowService
    {
        public void ShowWindow<T>(object DataContext) where T : Window, new()
        {
            Window window = new T();
            window.DataContext = DataContext;
            window.Show();
        }
    }
}
