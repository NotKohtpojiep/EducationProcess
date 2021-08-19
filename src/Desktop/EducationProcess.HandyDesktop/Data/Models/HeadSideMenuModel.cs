using System.Collections.Generic;
using GalaSoft.MvvmLight;

namespace EducationProcess.HandyDesktop.Data
{
    public class HeadSideMenuModel : ViewModelBase
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public bool IsNew { get; set; }
    }
}
