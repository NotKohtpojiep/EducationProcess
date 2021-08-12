using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.Data
{
    public class SideMenuModel : ObservableObject
    {
        public string Name { get; set; }
        public string TargetCtlName { get; set; }
        public bool IsSelected { get; set; }
        public string ImgPath { get; set; }
        public bool IsNew { get; set; }
        private bool _isVisible = true;
        public bool IsVisible
        {
            get => _isVisible;
            set => Set(ref _isVisible, value);
        }
    }
}
