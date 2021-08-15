using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using EducationProcess.HandyDesktop.Data;
using EducationProcess.HandyDesktop.Tools;

namespace EducationProcess.HandyDesktop.ViewModel
{
    public class NonClientAreaViewModel : ViewModelBase
    {
        public NonClientAreaViewModel()
        {
            VersionInfo = VersionHelper.GetVersion();
        }

        public RelayCommand<string> OpenViewCmd => new(OpenView);

        private void OpenView(string viewName)
        {
            Messenger.Default.Send<object>(null, MessageToken.ClearLeftSelected);
            Messenger.Default.Send(AssemblyHelper.CreateInternalInstance($"UserControl.{viewName}"), MessageToken.LoadShowContent);
        }

        public RelayCommand<string> CreateNewViewCmd => new(CreateNewView);

        private void CreateNewView(string viewName)
        {
            Messenger.Default.Send(AssemblyHelper.CreateInternalInstance($"UserControl.{viewName}"), "Niggers");
        }

        private string _versionInfo;

        public string VersionInfo
        {
            get => _versionInfo;
            set => Set(ref _versionInfo, value);
        }
    }
}
