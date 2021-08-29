using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EducationProcess.HandyDesktop.Data;

namespace EducationProcess.HandyDesktop.ViewModels
{
    public class ItemsDisplayViewModel : ViewModelBase<AvatarModel>
    {
        public ItemsDisplayViewModel(Func<List<AvatarModel>> getDataAction)
        {
            Task.Run(() => DataList = getDataAction?.Invoke()).ContinueWith(obj => DataGot = true);
        }

        private bool _dataGot;

        public bool DataGot
        {
            get => _dataGot;
            set => Set(ref _dataGot, value);
        }
    }
}
